using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mictco_Box
{
    public class ExTransactions : Transactions
    {
        public int SL { get; set; }
        public string CustomerName { get; set; }
        public string SlotName { get; set; }
        public string StaffName { get; set; }
    }

}
