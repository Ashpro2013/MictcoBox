using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Mictco_Box
{
    public partial class Main : Form
    {
        #region Private Variables
        DBContext db = new DBContext();
        List<Customer> customers;
        Customer customer;
        int? iCustomerId;
        #endregion

        #region Constructor
        public Main()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void OpenForm(Form frm, int X = 25, int Y = 25, string sForm = null)
        {
            try
            {
                if (frm.IsDisposed)
                {
                    Type type = frm.GetType();
                    Form form = (Form)Activator.CreateInstance(type);
                    form.TopLevel = false;
                    TabPage tbp = new TabPage();
                    tbp.Name = frm.Name;
                    tbp.Text = frm.Text;
                    tbp.BackgroundImageLayout = ImageLayout.Stretch;
                    tbp.BackColor = Color.FromArgb(32, 30, 45);
                    this.tabMdi.TabPages.Add(tbp);
                    this.tabMdi.SelectedTab = tbp;
                    tbp.Controls.Add(form);
                    form.Location = new Point(X, Y);
                    form.FormClosed += Form_FormClosed;
                    form.Show();
                    form.Focus();
                    form.BringToFront();
                }
                else
                {
                    frm.TopLevel = false;
                    TabPage tbp = new TabPage();
                    tbp.Name = frm.Name;
                    tbp.Text = frm.Text;
                    tbp.BackgroundImageLayout = ImageLayout.Stretch;
                    tbp.BackColor = Color.FromArgb(32, 30, 45);
                    this.tabMdi.TabPages.Add(tbp);
                    this.tabMdi.SelectedTab = tbp;
                    tbp.Controls.Add(frm);
                    frm.Location = new Point(X, Y);
                    frm.FormClosed += Form_FormClosed;
                    frm.Show();
                    frm.Focus();
                    frm.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            if (form.Parent is TabPage)
            {
                TabPage tbp = (TabPage)form.Parent;
                tabMdi.TabPages.Remove(tbp);
                tabMdi.SelectedTab = tabMdi.TabPages[0];
            }
        }
        private void CustomerLoadMethod()
        {
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
                GenerateReports(customer);
            }
        }
        private void GenerateReports(Customer customer)
        {
            List<Transactions> transactions = new List<Transactions>();
            transactions = db.Transactions.Where(x => x.FK_Customer == customer.Id).ToList();
            List<ExTransactions> exTransactions = new List<ExTransactions>();
            exTransactions = AniHelper.CopyListData<ExTransactions>(transactions.Cast<object>().ToList());
            int iNo = 1;
            foreach (var item in exTransactions)
            {
                item.SL = iNo;
                item.SlotName = db.Slots.FirstOrDefault(x => x.Id == item.FK_Slot).Name;
                item.StaffName = db.Staffs.FirstOrDefault(x => x.Id == item.FK_Staff).Name;
                item.CustomerName = db.Customers.FirstOrDefault(x => x.Id == item.FK_Customer).Name;
                iNo++;
            }
            dgvReports.AutoGenerateColumns = false;
            dgvReports.DataSource = exTransactions;
        }
        #endregion

        #region Events
        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            customers = new List<Customer>();
            AniHelper.FillCombo(cmbSlot, db.Slots.Where(x => x.OccupaidStatus == false).ToList().Cast<object>().ToList());
            AniHelper.FillCombo(cmbStaff, db.Staffs.Where(x => x.Name != "Admin").ToList().Cast<object>().ToList());
            lblUser.Text = db.Staffs.FirstOrDefault(x => x.Id == User.iUserId).Name;
            if (db.Boxes.Count == 0)
            {
                btnBox_Click(null, null);
            }
            customers = db.Customers;
            dgDetails.AutoGenerateColumns = false;
            dgDetails.DataSource = customers;
        }
        private void btnBox_Click(object sender, EventArgs e)
        {
            BoxView frm = new BoxView();
            OpenForm(frm);
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerView frm = new CustomerView();
            OpenForm(frm);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Messages.DialogMessage("Do You want close the application"))
            {
                Environment.Exit(0);
            }
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            this.tabMdi.SelectedTab = tpDashboard;
        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            TransactionView frm = new TransactionView();
            OpenForm(frm,0,0);
        }
        private void tabMdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabMdi.SelectedIndex==0)
            {
                txtSearch.Focus();
            }
        }
        private void btnAllReport_Click(object sender, EventArgs e)
        {
            Report frm = new Report();
            OpenForm(frm,0,0);
        }
        private void btnStaff_Click(object sender, EventArgs e)
        {
            StaffView frm = new StaffView();
            OpenForm(frm);
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            customers = db.Customers.Where(x => x.PanNumber.StartsWith(txtSearch.Text)).ToList();
            if(customers.Count==0)
            {
                customers = db.Customers.Where(x => x.Name.StartsWith(txtSearch.Text)).ToList();
                if(customers.Count==0)
                {
                    customers = db.Customers.Where(x => x.Company.StartsWith(txtSearch.Text)).ToList();
                    if (customers.Count == 0) { customers= db.Customers.Where(x => x.Careof.StartsWith(txtSearch.Text)).ToList(); }
                }
            }
            dgDetails.AutoGenerateColumns = false;
            dgDetails.DataSource = customers;
            if(customers.Count==1)
            {
                customer = customers.FirstOrDefault();
                CustomerLoadMethod();
                List<Transactions> transactions = new List<Transactions>();
                transactions = db.Transactions.Where(x => x.FK_Customer==customer.Id).ToList();
                List<ExTransactions> exTransactions = new List<ExTransactions>();
                exTransactions = AniHelper.CopyListData<ExTransactions>(transactions.Cast<object>().ToList());
                int iNo = 1;
                foreach (var item in exTransactions)
                {
                    item.SL = iNo;
                    item.SlotName = db.Slots.FirstOrDefault(x => x.Id == item.FK_Slot).Name;
                    item.StaffName = db.Staffs.FirstOrDefault(x => x.Id == item.FK_Staff).Name;
                    item.CustomerName = db.Customers.FirstOrDefault(x => x.Id == item.FK_Customer).Name;
                    iNo++;
                }
                dgvReports.AutoGenerateColumns = false;
                dgvReports.DataSource = exTransactions;
            }
        }
        private void dgDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                customer = (Customer)dgDetails.CurrentRow.DataBoundItem;
                CustomerLoadMethod();
            }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            iCustomerId = null;
            txtSearch.Text = string.Empty;
            customers = db.Customers;
            customer = new Customer();
            dgDetails.DataSource = customers;
            AniHelper.PanelClearMethod(pnlCustomer);
            AniHelper.FillCombo(cmbSlot, db.Slots.Where(x => x.OccupaidStatus == false).ToList().Cast<object>().ToList());
            AniHelper.FillCombo(cmbStaff, db.Staffs.Where(x => x.Name != "Admin").ToList().Cast<object>().ToList());
            btnInOrOut.Visible = false;
            txtSearch.Focus();
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
                isExpaired = cmbExpaired.SelectedIndex == 0 ? false : true
            };
            if (iCustomerId == null || !db.Customers.Any(x => x.Id == iCustomerId))
            {
                if (ORMForSDF.InsertToDatabaseObj(customer, "Customer", Properties.Settings.Default.Connection))
                {
                    customer = db.Customers.FirstOrDefault(x => x.Name == txtName.Text);
                    Slot slot = db.Slots.FirstOrDefault(x => x.Id == cmbSlot.SelectedValue.ToInt32());
                    slot.OccupaidStatus = true;
                    slot.InStatus = true;
                    slot.FK_CustomerId = customer.Id;
                    slot.FK_StaffId = cmbStaff.SelectedValue.ToInt32();
                    ORMForSDF.UpdateToDatabaseObj(slot, "Slot", "Id", slot.Id.toInt32(), Properties.Settings.Default.Connection);
                    var transaction = new Transactions { Id = null, FK_Customer = slot.FK_CustomerId, FK_Slot = slot.Id, FK_Staff = cmbStaff.SelectedValue.ToInt32(), Date = DateTime.Now.Date, Status = "Allotted", Remarks = "" };
                    if (ORMForSDF.InsertToDatabaseObj(transaction, "Transactions", Properties.Settings.Default.Connection))
                    {
                        var trans = new Transactions { Id = null, FK_Customer = slot.FK_CustomerId, FK_Slot = slot.Id, FK_Staff = cmbStaff.SelectedValue.ToInt32(), Date = DateTime.Now.Date, Status = "In", Remarks = "" };
                        if (ORMForSDF.InsertToDatabaseObj(trans, "Transactions", Properties.Settings.Default.Connection)) { Messages.SavedMessage(); btnClear_Click(null, null); }
                    }
                }
            }
            else
            {
                if (ORMForSDF.UpdateToDatabaseObj(customer, "Customer", "Id", iCustomerId.toInt32(), Properties.Settings.Default.Connection)) { Messages.UpdateMessage(); btnClear_Click(null, null); }
            }
        }

        private void cmbStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSave.PerformClick(); }
        }
    }
}