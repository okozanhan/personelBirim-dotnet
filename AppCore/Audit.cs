using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore
{
    public class Audit
    {
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? ModifiedUserId { get; set; } // ? Null olabaliceği
        public DateTime? ModifiedDate { get; set; }
    }
}
