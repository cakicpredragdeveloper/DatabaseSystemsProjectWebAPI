using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class RadniDanView
    {
        public int Id { get; set; }
        public DateTime DatumIVremePocetka { get; set; }
        public DateTime DatumIVremeZavrsetka { get; set; }
        public int BrojPrisutnihPoslanika { get; set; }
    }
}
