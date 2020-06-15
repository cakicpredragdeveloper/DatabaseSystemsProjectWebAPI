using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entities;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mappings
{
    class JeDodeljenaMap: ClassMap<JeDodeljena>
    {
        public JeDodeljenaMap()
        {
            Table("JE_DODELJENA");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            References(x => x.OrganizacionaJedinica).Column("ORGANIZACIONA_JEDINICA_ID");
            References(x => x.SluzbenaProstorija).Column("SLUZBENA_PROSTORIJA_ID");
        }
    }
}
