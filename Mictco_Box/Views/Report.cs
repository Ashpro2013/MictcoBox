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
            exCustomerDataGridView.DataSource = null;
            if (txtSearch.Text == string.Empty) { return; }
            List<ExCustomer> exCustomers = new List<ExCustomer>();
            DataTable dt = ORMForSDF.GetDataTableWithIdParameter_SP("spGetCustomerReport", new { sText = txtSearch.Text }, Properties.Settings.Default.Connection);
            int iCount = 1;
            foreach (DataRow item in dt.Rows)
            {
                ExCustomer exCustomer = new ExCustomer();
                exCustomer.SL = iCount;
                exCustomer.Id = item[0].ToInt32();
                exCustomer.Name = item[1].ToString();
                exCustomer.PanNumber = item[2].ToString();
                exCustomer.Company = item[3].ToString();
                exCustomer.Careof = item[4].ToString();
                exCustomer.isExpaired = item[5].ToString().ToBool();
                exCustomer.Staffname = item[6].ToString();
                exCustomer.Expaired = exCustomer.isExpaired ? "Expaired" : "Active";
                iCount++;
                exCustomers.Add(exCustomer);
            }
            exCustomerDataGridView.AutoGenerateColumns = false;
            exCustomerDataGridView.DataSource = exCustomers;
        }


        private void Report_Load(object sender, EventArgs e)
        {
           
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion
    }
}
