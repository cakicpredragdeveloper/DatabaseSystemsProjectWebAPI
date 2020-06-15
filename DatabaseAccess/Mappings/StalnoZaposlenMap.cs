using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Mappings
{
    class StalnoZaposlenMap : SubclassMap<StalnoZaposlen>
    {
        public StalnoZaposlenMap()
        {
            Table("STALNO_ZAPOSLEN");

            KeyColumn("ID");

            Map(x => x.Brk, "BRK");
            Map(x => x.RsGodine, "RS_GODINE");
            Map(x => x.RsMeseci, "RS_MESECI");
            Map(x => x.RsDani, "RS_DANI");
            Map(x => x.ImeFirme, "IME_FIRME");
        }
    }
}
