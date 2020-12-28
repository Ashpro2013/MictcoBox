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
                return ORMForSDF.GetListMethod<Box>("Select * From Box",Properties.Settings.Default.Connection);
            }
        }
        public List<Transactions> Transactions
        {
            get
            {
                return ORMForSDF.GetListMethod<Transactions>("Select * From Transactions", Properties.Settings.Default.Connection);
            }
        }
        public List<Slot> Slots
        {
            get
            {
                return ORMForSDF.GetListMethod<Slot>("Select * From Slot", Properties.Settings.Default.Connection);
            }
        }
        public List<Customer> Customers
        {
            get
            {
                return ORMForSDF.GetListMethod<Customer>("Select * From Customer", Properties.Settings.Default.Connection);
            }
        }
        public List<Staff> Staffs
        {
            get
            {
                return ORMForSDF.GetListMethod<Staff>("Select * From Staff", Properties.Settings.Default.Connection);
            }
        }
    }
}
