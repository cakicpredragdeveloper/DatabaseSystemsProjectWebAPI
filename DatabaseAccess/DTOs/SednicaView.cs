using DatabaseAccess.Entities;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class SednicaView
    {
        public int Id { get; set; }
        public int BrojSaziva { get; set; }
        public int BrojZasedanja { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }

        public SednicaView()
        { }

        public SednicaView(Sednica sednica)
        {
            this.Id = sednica.Id;
            this.BrojSaziva = sednica.BrojSaziva;
            this.BrojZasedanja = sednica.BrojZasedanja;
            this.DatumPocetka = sednica.DatumPocetka;
            this.DatumZavrsetka = sednica.DatumZavrsetka;
        }
    }
}
