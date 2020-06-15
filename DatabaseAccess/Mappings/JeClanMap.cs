using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entities;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mappings
{
    class JeClanMap : ClassMap<JeClan>
    {
        public JeClanMap()
        {
            Table("JE_CLAN");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            References(x => x.NarodniPoslanik).Column("NARODNI_POSLANIK_ID");
            References(x => x.OrganizacionaJedinica).Column("ORGANIZACIONA_JEDINICA_ID");
        }
    }
}
