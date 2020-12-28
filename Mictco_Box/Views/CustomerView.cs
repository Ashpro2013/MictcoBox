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
        public CustomerView()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtPanNo.Text == string.Empty) { Messages.WarningMessage(); return; }
            var customer = new Customer
            {
                Id = iCustomerId,
                Name = txtName.Text,
                City = txtCity.Text,
                EmailId = txtEmail.Text,
                PhoneNumebr = txtPhone.Text,
                PanNumber = txtPanNo.Text,
                Company = txtCompany.Text,
                GSTNumber = txtGSTNo.Text
            };

            if (iCustomerId==null ||!db.Customers.Any(x => x.Id == iCustomerId))
            {
                if (ORMForSDF.InsertToDatabaseObj(customer, "Customer", Properties.Settings.Default.Connection)) { Messages.SavedMessage(); btnClear_Click(null, null); }
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
            CustomerView_Load(null, null);
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Messages.DeleteConfirmationMessage() && iCustomerId != null)
            {
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
                    txtName.Text = customer.Name;
                    txtCity.Text = customer.City;
                    txtPanNo.Text = customer.PanNumber;
                    txtPhone.Text = customer.PhoneNumebr;
                    txtEmail.Text = customer.EmailId;
                    txtCompany.Text = customer.Company;
                    txtGSTNo.Text = customer.GSTNumber;
                    iCustomerId = customer.Id;
                }
            }
        }

        private void CustomerView_Load(object sender, EventArgs e)
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = db.Customers.ToList();
        }
    }
}