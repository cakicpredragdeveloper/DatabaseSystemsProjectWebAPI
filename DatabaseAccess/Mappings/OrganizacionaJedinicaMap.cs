using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Mappings
{
    class OrganizacionaJedinicaMap : ClassMap<OrganizacionaJedinica>
    {
        public OrganizacionaJedinicaMap()
        {
            Table("ORGANIZACIONA_JEDINICA");

            DiscriminateSubClassesOnColumn("TIP");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Predsednik).Column("PREDSEDNIK_ID").LazyLoad();
            References(x => x.Zamenik).Column("ZAMENIK_ID").LazyLoad();

            HasMany(x => x.JeClanNarodniPoslanici).KeyColumn("ORGANIZACIONA_JEDINICA_ID").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.JeDodeljenaSluzbeneProstorije).KeyColumn("ORGANIZACIONA_JEDINICA_ID").LazyLoad().Cascade.All().Inverse();
        }
    }

    class PoslanickaGrupaMap : SubclassMap<PoslanickaGrupa>
    {
        public PoslanickaGrupaMap()
        {
            DiscriminatorValue("poslanicka grupa");

            Map(x => x.Naziv, "NAZIV");
        }
    }

    class RadnoTeloMap : SubclassMap<RadnoTelo>
    {
        public RadnoTeloMap()
        {
            DiscriminatorValue("radno telo");

            Map(x => x.TipRadnogTela, "TIP_RADNOG_TELA");
        }
    }
}
