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
        public Transactions entTransactions { get; set; }
        #endregion

        #region Private Variables
        DBContext db = new DBContext();
        Slot slot;
        #endregion

        public SlotView()
        {
            InitializeComponent();
        }

        private void SlotView_Load(object sender, EventArgs e)
        {
            AniHelper.FillCombo(cmbStaff, db.Staffs.Where(x=> x.Name != "Admin").Cast<object>().ToList());
            if(entTransactions !=null)
            {
                slot = db.Slots.FirstOrDefault(x => x.Id == entTransactions.FK_Slot);
                lblBoxName.Text = db.Boxes.FirstOrDefault(x => x.Id == slot.FK_BoxId).Name;
                lblSlotName.Text = slot.Name;
                lblCustomer.Text = db.Customers.FirstOrDefault(x => x.Id == entTransactions.FK_Customer).Name;
                cmbStaff.SelectedValue = entTransactions.FK_Staff;
                cmbStaff.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            slot.InStatus = cmbInOrOut.SelectedIndex==0 ? false : true;
            slot.OccupaidStatus = cmbOccupaid.SelectedIndex==0 ? false : true;
            slot.FK_CustomerId = entTransactions.FK_Customer;
            slot.FK_StaffId = cmbStaff.SelectedValue.ToInt32();
            if (ORMForSDF.UpdateToDatabaseObj(slot, "Slot", "Id", slot.Id.toInt32(), Properties.Settings.Default.Connection))
            {
                string status = string.Empty;
                if (cmbOccupaid.SelectedIndex == 0)
                {
                    status = "Alotment Removed";
                }
                else
                {
                    if (cmbInOrOut.SelectedIndex == 0)
                    {
                        status = "Outed";
                    }
                    else
                    {
                        status = "In";
                    }
                }
                entTransactions.FK_Staff = cmbStaff.SelectedValue.ToInt32();
                entTransactions.Date = DateTime.Now;
                entTransactions.Status = status;
                if (ORMForSDF.InsertToDatabaseObj(entTransactions, "Transactions", Properties.Settings.Default.Connection)) { this.DialogResult = System.Windows.Forms.DialogResult.OK; this.Close(); }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel; this.Close();
        }
    }
}