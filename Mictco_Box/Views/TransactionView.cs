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
    public partial class TransactionView : Form
    {
        #region Constructor
        public TransactionView()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void txtPanNo_TextChanged(object sender, EventArgs e)
        {
            dgvReports.DataSource = null;
            List<ExTransactions> exTransactions = new List<ExTransactions>();
            exTransactions = ORMForSDF.GetList_SP<ExTransactions>("spGetTransactionReport", new { sText = txtSearch.Text }, Properties.Settings.Default.Connection);
            dgvReports.AutoGenerateColumns = false;
            dgvReports.DataSource = exTransactions;
        }
        private void TransactionView_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion
    }
}