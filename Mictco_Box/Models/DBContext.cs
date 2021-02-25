using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mictco_Box
{
    public class DBContext
    {
        public List<Box> Boxes
        {
            get
            {
                return ORMForSDF.GetList_SP<Box>("spGetBox",Properties.Settings.Default.Connection);
            }
        }
        public List<Transactions> Transactions
        {
            get
            {
                return ORMForSDF.GetList_SP<Transactions>("spGetTransactions", Properties.Settings.Default.Connection);
            }
        }
        public List<Slot> Slots
        {
            get
            {
                return ORMForSDF.GetList_SP<Slot>("spGetSlot", Properties.Settings.Default.Connection);
            }
        }
        public List<Customer> Customers
        {
            get
            {
                return ORMForSDF.GetList_SP<Customer>("spGetCustomer", Properties.Settings.Default.Connection);
            }
        }
        public List<Staff> Staffs
        {
            get
            {
                return ORMForSDF.GetList_SP<Staff>("spGetStaff", Properties.Settings.Default.Connection);
            }
        }
    }
}
