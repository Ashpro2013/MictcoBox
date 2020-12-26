using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mictco_Box
{
    public class Box
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public int FK_StaffId { get; set; }
    }
}
