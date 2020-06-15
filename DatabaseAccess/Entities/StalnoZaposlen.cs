using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class StalnoZaposlen : NarodniPoslanik
    {
        public virtual int Brk { get; set; }
        public virtual int RsGodine { get; set; }
        public virtual int RsMeseci { get; set; }
        public virtual int RsDani { get; set; }
        public virtual string ImeFirme { get; set; }
    }
}
