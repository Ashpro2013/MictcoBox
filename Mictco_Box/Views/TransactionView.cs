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
        private Slot getCurrent()
        {
            try
            {
                if (dgvSlots.CurrentRow != null)
                {
                    Slot slot = (Slot)dgvSlots.CurrentRow.DataBoundItem;
                    return slot;
                }
                else
                {
                    return null;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dgvLoad(Customer customer)
        {
            List<Slot> slots = new List<Slot>();
            slots = db.Slots.Where(x => x.FK_CustomerId == customer.Id && x.OccupaidStatus == 1).ToList();
            dgvSlots.AutoGenerateColumns = false;
            if (slots.Count > 0)
            {
                dgvSlots.DataSource = slots;
            }
            Slot slot = new Slot();
            slot = slots.FirstOrDefault();
            GenerateReports(slot);
        }
        private void GenerateReports(Slot slot)
        {
            List<Transactions> transactions = new List<Transactions>();
            transactions = db.Transactions.Where(x => x.FK_Slot == slot.Id).ToList();
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
            customer=db.Customers.FirstOrDefault(x => x.PanNumber.Contains(txtSearch.Text));
            if(customer !=null)
            {
                dgvLoad(customer);
            }
            else
            {
                customer = db.Customers.FirstOrDefault(x => x.Name.Contains(txtSearch.Text));
                if(customer !=null)
                {
                    dgvLoad(customer);
                }
                else
                {
                    customer = db.Customers.FirstOrDefault(x => x.PhoneNumebr.Contains(txtSearch.Text));
                    if(customer!=null)
                    {
                        dgvLoad(customer);
                    }
                }
            }
        }
        private void dgvSlots_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                Slot slot = getCurrent();
                GenerateReports(slot);
            }
        }
        private void TransactionView_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion
    }
}