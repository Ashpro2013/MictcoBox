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
    public partial class CustomerView : Form
    {
        #region Privatevariables
        int? iCustomerId;
        DBContext db = new DBContext();
        #endregion

        #region Constructor
        public CustomerView()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtPanNo.Text == string.Empty) { Messages.WarningMessage(); return; }
            var customer = new Customer
            {
                Id = iCustomerId,
                Name = txtName.Text,
                PanNumber = txtPanNo.Text,
                Company = txtCompany.Text,
                Careof = txtCareof.Text,
                Password = txtPassword.Text,
                Fk_SlotId = cmbSlot.SelectedValue.ToInt32(),
                Fk_StaffId = cmbStaff.SelectedValue.ToInt32(),
                isExpaired = cmbExpaired.SelectedIndex==0 ? false : true
            };
            if (iCustomerId==null ||!db.Customers.Any(x => x.Id == iCustomerId))
            {
                if (ORMForSDF.InsertToDatabaseObj(customer, "Customer", Properties.Settings.Default.Connection))
                {
                    customer = db.Customers.FirstOrDefault(x => x.Name == txtName.Text);
                    Slot slot = db.Slots.FirstOrDefault(x => x.Id == cmbSlot.SelectedValue.ToInt32());
                    slot.OccupaidStatus = true;
                    slot.InStatus = true;
                    slot.FK_CustomerId = customer.Id;
                    slot.FK_StaffId = User.iUserId;
                    ORMForSDF.UpdateToDatabaseObj(slot, "Slot", "Id", slot.Id.toInt32(), Properties.Settings.Default.Connection);
                    var transaction = new Transactions { Id = null, FK_Customer = slot.FK_CustomerId, FK_Slot = slot.Id, FK_Staff = User.iUserId, Date = DateTime.Now.Date, Status = "Allotted", Remarks = "" };
                    if (ORMForSDF.InsertToDatabaseObj(transaction, "Transactions", Properties.Settings.Default.Connection))
                    {
                        var trans = new Transactions { Id = null, FK_Customer = slot.FK_CustomerId, FK_Slot = slot.Id, FK_Staff = User.iUserId, Date = DateTime.Now.Date, Status = "In", Remarks = "" };
                        if (ORMForSDF.InsertToDatabaseObj(trans, "Transactions", Properties.Settings.Default.Connection)) { Messages.SavedMessage(); btnClear_Click(null, null); }
                    }
                }
            }
            else
            {
                if (ORMForSDF.UpdateToDatabaseObj(customer, "Customer", "Id", iCustomerId.toInt32(), Properties.Settings.Default.Connection)) { Messages.UpdateMessage(); btnClear_Click(null, null); }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            iCustomerId = null;
            AniHelper.ClearMethod(this);
            AniHelper.FillCombo(cmbSlot, db.Slots.Where(x => x.OccupaidStatus == false).ToList().Cast<object>().ToList());
            AniHelper.FillCombo(cmbStaff, db.Staffs.Where(x => x.Name != "Admin").ToList().Cast<object>().ToList());
            btnInOrOut.Visible = false;
            txtPanNo.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Messages.DeleteConfirmationMessage() && iCustomerId != null)
            {
                foreach (var item in db.Slots.Where(x => x.FK_CustomerId == iCustomerId))
                {
                    item.InStatus = false;
                    item.OccupaidStatus = false;
                    ORMForSDF.UpdateToDatabaseObj(item, "Slot", "Id", item.Id.toInt32(), Properties.Settings.Default.Connection);
                }
                ORMForSDF.DeleteFromDatabase("Transactions", "FK_Customer", iCustomerId.ToInt32(), Properties.Settings.Default.Connection);
                if (ORMForSDF.DeleteFromDatabase("Customer", "Id", iCustomerId.toInt32(), Properties.Settings.Default.Connection)) { btnClear_Click(null, null); }
            }
        }
        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Customer customer = db.Customers.FirstOrDefault(x=> x.Name==dgvStaff.CurrentRow.Cells[0].Value.ToString());
                if (customer != null)
                {
                    AniHelper.FillCombo(cmbSlot, db.Slots.Cast<object>().ToList());
                    txtName.Text = customer.Name;
                    txtPassword.Text = customer.Password;
                    txtPanNo.Text = customer.PanNumber;
                    txtCareof.Text = customer.Careof;
                    txtCompany.Text = customer.Company;
                    iCustomerId = customer.Id;
                    cmbStaff.SelectedValue = customer.Fk_StaffId;
                    cmbSlot.SelectedValue = customer.Fk_SlotId;
                    cmbExpaired.SelectedIndex = customer.isExpaired ? 1 : 0;
                    btnInOrOut.Visible = true;
                }
            }
        }
        private void CustomerView_Load(object sender, EventArgs e)
        {
            AniHelper.FillCombo(cmbSlot,db.Slots.Where(x => x.OccupaidStatus == false).ToList().Cast<object>().ToList());
            AniHelper.FillCombo(cmbStaff, db.Staffs.Where(x => x.Name != "Admin").ToList().Cast<object>().ToList());
            BindDGV(db.Customers.ToList());
            this.ActiveControl = txtPanNo;
        }
        private void BindCombo(List<Slot> slots)
        {
            if (slots.Count == 0) { Messages.ErrorMessage("Please create Boxes and Slot first.");  }
            cmbSlot.ValueMember = "Id";
            cmbSlot.DisplayMember = "Name";
            cmbSlot.DataSource = slots;
        }
        private void BindDGV(List<Customer> entCustomers)
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = entCustomers;
        }
        private void txtPanNo_TextChanged(object sender, EventArgs e)
        {
            BindDGV(db.Customers.Where(x => x.PanNumber.StartsWith(txtPanNo.Text)).ToList());
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            BindDGV(db.Customers.Where(x => x.Name.StartsWith(txtName.Text)).ToList());
        }
        private void btnInOrOut_Click(object sender, EventArgs e)
        {
            if (iCustomerId != null)
            {
                SlotView frm = new SlotView();
                Transactions transactions = new Transactions();
                transactions.FK_Customer = iCustomerId;
                transactions.FK_Slot = cmbSlot.SelectedValue.ToInt32();
                transactions.FK_Staff = cmbStaff.SelectedValue.ToInt32();
                frm.entTransactions = transactions;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    btnClear_Click(null, null);
                }
            }
        }
        #endregion
    }
}