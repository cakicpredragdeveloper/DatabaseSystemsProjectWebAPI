using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Mappings
{
    class NarodniPoslanikMap : ClassMap<NarodniPoslanik>
    {
        public NarodniPoslanikMap()
        {
            Table("NARODNI_POSLANIK");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Jib, "JIB");
            Map(x => x.Jmbg, "JMBG");
            Map(x => x.LicnoIme, "LICNO_IME");
            Map(x => x.ImeRoditelja, "IME_RODITELJA");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Map(x => x.MestoRodjenja, "MESTO_RODJENJA");
            Map(x => x.IzbornaLista, "IZBORNA_LISTA");
            Map(x => x.MestoStanovanja, "MESTO_STANOVANJA");
            Map(x => x.AdresaStanovanja, "ADRESA_STANOVANJA");

            HasMany(x => x.Telefoni).KeyColumn("NARODNI_POSLANIK_ID").Cascade.All().Inverse();

            HasMany(x => x.JePredsednik).KeyColumn("PREDSEDNIK_ID").Cascade.All().Inverse();
            HasMany(x => x.JeZamenik).KeyColumn("ZAMENIK_ID").Cascade.All().Inverse();

            HasMany(x => x.JeClanOrganizacionihJedinica).KeyColumn("NARODNI_POSLANIK_ID").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.JePredlozioAkte).KeyColumn("NARODNI_POSLANIK_ID").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.JeSazvaoSednice).KeyColumn("NARODNI_POSLANIK_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
