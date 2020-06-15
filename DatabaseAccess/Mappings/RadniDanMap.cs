using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Mappings
{
    public class RadniDanMap : ClassMap<RadniDan>
    {
        public RadniDanMap()
        {
            Table("RADNI_DAN");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.DatumIVremePocetka, "DATUM_I_VREME_POCETKA");
            Map(x => x.DatumIVremeZavrsetka, "DATUM_I_VREME_ZAVRSETKA");
            Map(x => x.BrojPrisutnihPoslanika, "BROJ_PRISUTNIH_POSLANIKA");

            References(x => x.Sednica).Column("SEDNICA_ID").LazyLoad();
        }
    }
}
