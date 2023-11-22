using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBirim.DAL.DataTransferObject.Birim
{
    public class AddBirimDto
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Mail { get; set; }
    }
}
