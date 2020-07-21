using DatabaseAccess.Entities;
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

        public RadniDanView()
        { }

        public RadniDanView(RadniDan radniDan)
        {
            this.Id = radniDan.Id;
            this.DatumIVremePocetka = radniDan.DatumIVremePocetka;
            this.DatumIVremeZavrsetka = radniDan.DatumIVremeZavrsetka;
            this.BrojPrisutnihPoslanika = radniDan.BrojPrisutnihPoslanika;
        }
    }
}
