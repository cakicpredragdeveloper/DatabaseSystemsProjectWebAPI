using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Mappings
{
    class SluzbenaProstorijaMap : ClassMap<SluzbenaProstorija>
    {
        public SluzbenaProstorijaMap()
        {
            Table("SLUZBENA_PROSTORIJA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Sprat, "SPRAT");
            Map(x => x.Broj, "BROJ");

            HasMany(x => x.JeDodeljenaOrganizacionimJedinicama).KeyColumn("SLUZBENA_PROSTORIJA_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
