using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mictco_Box
{
    public partial class SlotView : Form
    {
        #region Public Properies
        public Slot slot { get; set; }
        #endregion

        #region Private Variables
        DBContext db = new DBContext();
        #endregion

        public SlotView()
        {
            InitializeComponent();
        }

        private void SlotView_Load(object sender, EventArgs e)
        {
            cmbCustomer.ValueMember = "Id";
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.DataSource = db.Customers.ToList();
            cmbStaff.ValueMember = "Id";
            cmbStaff.DisplayMember = "Name";
            cmbStaff.DataSource = db.Staffs.ToList();
            cmbStaff.SelectedValue = User.iUserId;
            cmbStaff.Enabled = false;
            lblBoxName.Text = db.Boxes.FirstOrDefault(x => x.Id == slot.FK_BoxId).Name;
            lblSlotName.Text = slot.Name;
            cmbInOrOut.SelectedIndex= slot.InStatus;
            cmbOccupaid.SelectedIndex = slot.OccupaidStatus;
            if (slot.FK_CustomerId != null)
            {
                cmbCustomer.SelectedValue = slot.FK_CustomerId;
            }
            if (slot.FK_StaffId != null)
            {
                cmbStaff.SelectedValue = slot.FK_StaffId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            slot.InStatus = cmbInOrOut.SelectedIndex;
            slot.OccupaidStatus = cmbOccupaid.SelectedIndex;
            slot.FK_CustomerId = cmbCustomer.SelectedValue.ToInt32();
            slot.FK_StaffId = cmbStaff.SelectedValue.ToInt32();
            if (ORMForSDF.UpdateToDatabaseObj(slot, "Slot", "Id", slot.Id.toInt32(), Properties.Settings.Default.Connection)) 
            {
                string status = string.Empty;
                if(cmbOccupaid.SelectedIndex==0 )
                {
                    status = "Alotment Removed";
                }
                else
                {
                    if(cmbInOrOut.SelectedIndex==0)
                    {
                        status = "Outed";
                    }
                    else
                    {
                        status = "In";
                    }
                }
                var transaction = new Transactions { Id=null,FK_Customer = slot.FK_CustomerId,FK_Slot = slot.Id,FK_Staff=User.iUserId,Date = DateTime.Now.Date,Status=status,Remarks=""};
                if (ORMForSDF.InsertToDatabaseObj(transaction, "Transactions", Properties.Settings.Default.Connection)) { this.DialogResult = System.Windows.Forms.DialogResult.OK; this.Close(); }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel; this.Close();
        }
    }
}