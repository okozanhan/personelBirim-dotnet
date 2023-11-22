using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBirim.DAL.Entity
{
    public class Birim : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Mail { get; set; }
        public ICollection<Personel> Personeller { get; set; }
        public bool IsDeleted { get; set; }

    }
}
