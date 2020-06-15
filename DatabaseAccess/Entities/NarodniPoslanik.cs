using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class NarodniPoslanik
    {
        public virtual int Id { get; protected set; }
        public virtual int Jib { get; set; }
        public virtual Int64 Jmbg { get; set; }
        public virtual string LicnoIme { get; set; }
        public virtual string ImeRoditelja { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string MestoRodjenja { get; set; }
        public virtual string IzbornaLista { get; set; }
        public virtual string MestoStanovanja { get; set; }
        public virtual string AdresaStanovanja { get; set; }

        public virtual IList<Telefon> Telefoni { get; set; }


        public virtual IList<OrganizacionaJedinica> JePredsednik { get; set; }
        public virtual IList<OrganizacionaJedinica> JeZamenik { get; set; }

        public virtual IList<JeClan> JeClanOrganizacionihJedinica { get; set; }

        public virtual IList<JePredlozio> JePredlozioAkte { get; set; }

        public virtual IList<JeSazvalo> JeSazvaoSednice { get; set; }

        public NarodniPoslanik()
        {
            Telefoni = new List<Telefon>();
            JePredsednik = new List<OrganizacionaJedinica>();
            JeZamenik = new List<OrganizacionaJedinica>();

            JeClanOrganizacionihJedinica = new List<JeClan>();

            JePredlozioAkte = new List<JePredlozio>();

            JeSazvaoSednice = new List<JeSazvalo>();
        }
    }
}

