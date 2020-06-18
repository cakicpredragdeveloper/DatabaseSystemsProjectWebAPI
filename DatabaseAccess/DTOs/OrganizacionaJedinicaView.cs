using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class OrganizacionaJedinicaView
    {
        public virtual int Id { get; protected set; }
        public virtual string Tip { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string TipRadnogTela { get; set; }

        public virtual NarodniPoslanikView Predsednik { get; set; }
        public virtual NarodniPoslanikView Zamenik { get; set; }

        public virtual IList<JeClanView> JeClanNarodniPoslanici { get; set; }

        public virtual IList<JeDodeljenaView> JeDodeljenaSluzbeneProstorije { get; set; }

        public OrganizacionaJedinicaView()
        {
            JeClanNarodniPoslanici = new List<JeClanView>();

            JeDodeljenaSluzbeneProstorije = new List<JeDodeljenaView>();
        }

        public OrganizacionaJedinicaView(OrganizacionaJedinica organizacionaJedinica)
        {
            Id = organizacionaJedinica.Id;
            Tip = organizacionaJedinica.Tip;
            Naziv = organizacionaJedinica.Naziv;
            TipRadnogTela = organizacionaJedinica.TipRadnogTela;

            Predsednik = new NarodniPoslanikView(organizacionaJedinica.Predsednik);
            Zamenik = new NarodniPoslanikView(organizacionaJedinica.Zamenik);
        }
    }
}
