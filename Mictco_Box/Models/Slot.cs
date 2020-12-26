using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mictco_Box
{
    public class Slot
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int FK_BoxId { get; set; }
        public int? FK_StaffId { get; set; }
        public int? FK_CustomerId { get; set; }
        public bool InStatus { get; set; }
        public bool OccupaidStatus { get; set; }
    }
}
