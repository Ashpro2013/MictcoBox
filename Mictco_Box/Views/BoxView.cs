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
        List<Slot> slots = new List<Slot>();
        List<Slot> oldSlots = new List<Slot>();
        #endregion
        public BoxView()
        {
            InitializeComponent();
        }
        private void BoxView_Load(object sender, EventArgs e)
        {
            dgBox.AutoGenerateColumns = false;
            dgBox.DataSource = db.Boxes.ToList();
            dgSlot.AutoGenerateColumns = false;
            slots = new List<Slot>();
            dgSlot.DataSource = slots;
            cmbStaff.DisplayMember = "Name";
            cmbStaff.ValueMember = "Id";
            cmbStaff.DataSource = db.Staffs.ToList();
            cmbStaff.SelectedValue = User.iUserId;
            this.ActiveControl = txtName;
        }


        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Box box = db.Boxes.FirstOrDefault(x => x.Name == dgBox.CurrentRow.Cells[0].Value.ToString());
                iBoxId = box.Id;
                txtName.Text = box.Name;
                cmbStaff.SelectedValue = box.FK_StaffId;
                txtSlotCount.Text = db.Slots.Where(x => x.FK_BoxId == iBoxId).Count().ToString();
                txtName.Enabled = false;
                slots = db.Slots.Where(x => x.FK_BoxId == box.Id).ToList();
                oldSlots = db.Slots.Where(x => x.FK_BoxId == box.Id).ToList();
                dgSlot.AutoGenerateColumns = false;
                dgSlot.DataSource = null;
                dgSlot.DataSource = slots;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty && slots.Count >0) { Messages.ErrorMessage("Please fill the details."); return; }
            var box = new Box
            {
                Id = iBoxId,
                Name = txtName.Text,
                FK_StaffId = cmbStaff.SelectedValue.ToInt32(),
                CreatedOn = DateTime.Now.Date
            };
            if (iBoxId==null)
            {
                if (ORMForSDF.InsertToDatabaseObj(box, "Box", Properties.Settings.Default.Connection))
                {
                    box = db.Boxes.FirstOrDefault(x=> x.Name==txtName.Text);
                    if (box.Id != null)
                    {
                        foreach (var item in slots)
                        {
                            item.FK_BoxId = box.Id.ToInt32();
                        }
                        ORMForSDF.InsertToDatabase(slots.Cast<object>().ToList(), "Slot", Properties.Settings.Default.Connection);
                        Messages.SavedMessage();
                        btnClear_Click(null, null);
                    }

                }
            }
            else
            {
                if (ORMForSDF.UpdateToDatabaseObj(box, "Box", "Id", iBoxId.toInt32(), Properties.Settings.Default.Connection))
                {
                    if (iBoxId != null)
                    {
                        foreach (var item in slots)
                        {
                            item.FK_BoxId = iBoxId.ToInt32();
                        }
                        ORMForSDF.UpdateDatabase(slots.Cast<object>().ToList(), oldSlots.Cast<object>().ToList(), "Slot", "Id", Properties.Settings.Default.Connection);
                        Messages.UpdateMessage();
                        btnClear_Click(null, null);
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
            slots = new List<Slot>();
            oldSlots = new List<Slot>();
            dgSlot.DataSource = null;
            dgBox.AutoGenerateColumns = false;
            dgBox.DataSource = db.Boxes.ToList();
            iBoxId = null;
            txtName.Enabled = true;
            txtName.Focus();

        }

       
        private void txtSlotCount_Validated(object sender, EventArgs e)
        {
            dgSlot.DataSource = null;
            int iStart = 0;
            if (slots.Count == 0)
            {
                iStart = 1;
            }
            else
            {
                iStart = slots.Count+1;
            }
            for (int i = iStart; i < txtSlotCount.Text.ToInt32() + 1; i++)
            {
                Slot slot = new Slot();
                slot.Name = txtName.Text + i.ToString();
                slot.InStatus = false;
                slot.OccupaidStatus = false;
                slot.FK_StaffId = cmbStaff.SelectedValue.ToInt32();
                slots.Add(slot);
            }
            dgSlot.AutoGenerateColumns = false;
            dgSlot.DataSource = slots;
        }

        private void txtSlotCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSlotCount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtSlotCount_Validated(null, null);
                btnSave_Click(null, null);
            }
        }
    }
}