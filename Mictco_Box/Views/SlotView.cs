using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Mictco_Box
{
    public partial class SlotView : DevExpress.XtraEditors.XtraForm
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
            lblBoxName.Text = db.Boxes.FirstOrDefault(x => x.Id == slot.FK_BoxId).Name;
            lblSlotName.Text = slot.Name;
            cbIn.Checked = slot.InStatus;
            cbOccupied.Checked = slot.OccupaidStatus;
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
            slot.InStatus = cbIn.Checked;
            slot.OccupaidStatus = cbOccupied.Checked;
            slot.FK_CustomerId = cmbCustomer.SelectedValue.ToInt32();
            slot.FK_StaffId = cmbStaff.SelectedValue.ToInt32();
            if (ORMForSDF.UpdateToDatabaseObj(slot, "Slot", "Id", slot.Id.toInt32(), Properties.Settings.Default.Connection)) { this.DialogResult = System.Windows.Forms.DialogResult.OK; this.Close(); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel; this.Close();
        }
    }
}