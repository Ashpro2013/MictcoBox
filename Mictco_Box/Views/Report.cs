using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mictco_Box
{
    public partial class Report : Form
    {
        #region Private Variables
        DBContext db = new DBContext();
        #endregion

        #region Constructor
        public Report()
        {
            InitializeComponent();
        }
        #endregion

        #region Events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Customer> customers = new List<Customer>();
            customers = db.Customers.Where(x => x.PanNumber.StartsWith(txtSearch.Text)).ToList();
            if (customers.Count == 0)
            {
                customers = db.Customers.Where(x => x.Name.StartsWith(txtSearch.Text)).ToList();
                if (customers.Count == 0)
                {
                    customers = db.Customers.Where(x => x.Company.StartsWith(txtSearch.Text)).ToList();
                    if (customers.Count == 0) { customers = db.Customers.Where(x => x.Careof.StartsWith(txtSearch.Text)).ToList(); }
                }
            }
            dgvLoad(AniHelper.CopyListData<ExCustomer>(customers.Cast<object>().ToList()));

        }

        private void dgvLoad(List<ExCustomer> entCustomer)
        {
            int iCount = 1;
            foreach (var item in entCustomer)
            {
                item.SL = iCount;
                item.Staffname = db.Staffs.FirstOrDefault(x => x.Id == item.Fk_StaffId).Name;
                iCount++;
            }
            exCustomerDataGridView.DataSource = entCustomer;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            List<Customer> entCustomer = new List<Customer>();
            entCustomer = db.Customers.ToList();
            dgvLoad(AniHelper.CopyListData<ExCustomer>(entCustomer.Cast<object>().ToList()));
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion
    }
}
