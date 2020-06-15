using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class RadniDan
    {
        public virtual int Id { get; set; }
        public virtual DateTime DatumIVremePocetka { get; set; }
        public virtual DateTime DatumIVremeZavrsetka { get; set; }
        public virtual int BrojPrisutnihPoslanika { get; set; }
        public virtual Sednica Sednica { get; set; }

        public RadniDan()
        {

        }
    }
}
