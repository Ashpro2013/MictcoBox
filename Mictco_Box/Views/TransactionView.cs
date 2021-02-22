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
        #region Private Variables
        DBContext db = new DBContext();
        #endregion

        #region Constructor
        public TransactionView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
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
        private void txtPanNo_TextChanged(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer=db.Customers.FirstOrDefault(x => x.PanNumber.StartsWith(txtSearch.Text));
            if(customer ==null)
            {
                customer = db.Customers.FirstOrDefault(x => x.Name.StartsWith(txtSearch.Text));
                if(customer==null)
                {
                    customer = db.Customers.FirstOrDefault(x => x.Company.StartsWith(txtSearch.Text));
                }
            }
            GenerateReports(customer);
        }
        private void TransactionView_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion
    }
}