using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mictco_Box
{
    public class Customer
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string PanNumber { get; set; }
        public string Company { get; set; }
        public string Careof { get; set; }
        public string Password { get; set; }
        public bool isExpaired { get; set; }
        public int Fk_StaffId { get; set; }
        public int Fk_SlotId { get; set; }
    }
}
