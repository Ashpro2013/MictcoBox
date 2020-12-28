using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mictco_Box
{
    public class Transactions
    {
        public int? Id { get; set; }
        public int? FK_Customer { get; set; }
        public int? FK_Slot { get; set; }
        public int? FK_Staff { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }

}
