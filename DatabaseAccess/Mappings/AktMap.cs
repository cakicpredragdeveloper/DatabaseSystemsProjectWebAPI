using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Mappings
{
    class AktMap : ClassMap<Akt>
    {
        public AktMap()
        {
            Table("AKT");

            DiscriminateSubClassesOnColumn("TIP_PREDLOZIOCA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.TipAkta, "TIP");
        }
    }

    class AktNarodnihPoslanikaMap : SubclassMap<AktNarodnihPoslanika>
    {
        public AktNarodnihPoslanikaMap()
        {
            DiscriminatorValue("narodni poslanici");

            HasMany(x => x.JePredlozioNarodniPoslanici).KeyColumn("AKT_ID").LazyLoad().Cascade.All().Inverse();
        }
    }

    class AktVladeMap : SubclassMap<AktVlade>
    {
        public AktVladeMap()
        {
            DiscriminatorValue("vlada");
        }
    }

    class AktViseOd1500BiracaMap : SubclassMap<AktViseOd1500Biraca>
    {
        public AktViseOd1500BiracaMap()
        {
            DiscriminatorValue("biraci");

            Map(x => x.BrojBiraca, "BROJ_BIRACA");
        }
    }
}
