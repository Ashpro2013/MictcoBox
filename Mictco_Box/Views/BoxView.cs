using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mictco_Box
{
    public partial class BoxView : Form
    {
        #region Private Variables
        int? iBoxId;
        DBContext db = new DBContext();
        #endregion
        public BoxView()
        {
            InitializeComponent();
        }

        private void BoxView_Load(object sender, EventArgs e)
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = db.Boxes.ToList();
            cmbStaff.DisplayMember = "Name";
            cmbStaff.ValueMember = "Id";
            cmbStaff.DataSource = db.Staffs.ToList();
            cmbStaff.SelectedValue = User.iUserId;
            cmbStaff.Enabled = false;
            this.ActiveControl = txtName;
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Box box = db.Boxes.FirstOrDefault(x => x.Name == dgvStaff.CurrentRow.Cells[0].Value.ToString());
                iBoxId = box.Id;
                txtName.Text = box.Name;
                cmbStaff.SelectedValue = box.FK_StaffId;
                txtSlotCount.Text = db.Slots.Where(x => x.FK_BoxId == iBoxId).Count().ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty && lbSlots.Items.Count<1) { Messages.ErrorMessage("Please fill the details."); return; }
            var box = new Box
            {
                Id = iBoxId,
                Name = txtName.Text,
                FK_StaffId = cmbStaff.SelectedValue.ToInt32(),
                CreatedOn = DateTime.Now.Date
            };
            if (iBoxId==null || !db.Boxes.Any(x => x.Id == iBoxId))
            {
                if (ORMForSDF.InsertToDatabaseObj(box, "Box", Properties.Settings.Default.Connection))
                {
                    box = db.Boxes.FirstOrDefault(x=> x.Name==txtName.Text);
                    if (box.Id != null)
                    {
                        foreach (var item in lbSlots.Items)
                        {
                            ORMForSDF.InsertToDatabaseObj(new Slot { Id = null, Name = item.ToString(), FK_BoxId = box.Id.toInt32(), FK_CustomerId = null, FK_StaffId = null, InStatus = 0, OccupaidStatus = 0 }, "Slot", Properties.Settings.Default.Connection);
                        }
                        Messages.SavedMessage();
                        btnClear_Click(null, null);
                    }

                }
            }
            else
            {
                if (ORMForSDF.DeleteFromDatabase("Slot", "FK_BoxId", iBoxId.toInt32(), Properties.Settings.Default.Connection))
                {
                    if (ORMForSDF.UpdateToDatabaseObj(box, "Box", "Id", iBoxId.toInt32(), Properties.Settings.Default.Connection))
                    {
                        if (box.Id != null)
                        {
                            foreach (var item in lbSlots.Items)
                            {
                                ORMForSDF.InsertToDatabaseObj(new Slot { Id = null, Name = item.ToString(), FK_BoxId = box.Id.toInt32(), FK_CustomerId = null, FK_StaffId = null, InStatus = 0, OccupaidStatus = 0 }, "Slot", Properties.Settings.Default.Connection);
                            }
                            Messages.UpdateMessage();
                            btnClear_Click(null, null);
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Messages.DeleteConfirmationMessage() && iBoxId!=null)
            {
                if (ORMForSDF.DeleteFromDatabase("Slot", "FK_BoxId", iBoxId.toInt32(), Properties.Settings.Default.Connection))
                {
                    if (ORMForSDF.DeleteFromDatabase("Box", "Id", iBoxId.toInt32(), Properties.Settings.Default.Connection)) { btnClear_Click(null, null); }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            AniHelper.ClearMethod(this);
            lbSlots.Items.Clear();
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = db.Boxes.ToList();
            iBoxId = null;
            txtName.Focus();

        }

       
        private void txtSlotCount_Validated(object sender, EventArgs e)
        {
            lbSlots.Items.Clear();
            for (int i = 1; i < txtSlotCount.Text.ToInt32() + 1; i++)
            {
                lbSlots.Items.Add(txtName.Text + i.ToString());
            }
        }

        private void txtSlotCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}