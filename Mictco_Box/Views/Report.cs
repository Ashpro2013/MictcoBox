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
            List<Customer> entCustomer = new List<Customer>();
            entCustomer = db.Customers.Where(x => x.PanNumber.Contains(txtSearch.Text)).ToList();
            if (entCustomer.Count>0)
            {
                dgvLoad(AniHelper.CopyListData<ExCustomer>(entCustomer.Cast<object>().ToList()));
            }
            else
            {
                entCustomer = db.Customers.Where(x => x.Name.Contains(txtSearch.Text)).ToList();
                if (entCustomer.Count > 0)
                {
                    dgvLoad(AniHelper.CopyListData<ExCustomer>(entCustomer.Cast<object>().ToList()));
                }
                else
                {
                    entCustomer = db.Customers.Where(x => x.PhoneNumebr.Contains(txtSearch.Text)).ToList();
                    if (entCustomer.Count > 0)
                    {
                        dgvLoad(AniHelper.CopyListData<ExCustomer>(entCustomer.Cast<object>().ToList()));
                    }
                }
            }

        }

        private void dgvLoad(List<ExCustomer> entCustomer)
        {
            int iCount = 1;
            foreach (var item in entCustomer)
            {
                item.SL = iCount;
                iCount++;
            }
            dgvReports.AutoGenerateColumns = false;
            dgvReports.DataSource = entCustomer;
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
