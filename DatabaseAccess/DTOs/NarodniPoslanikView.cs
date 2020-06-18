using System;
using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class NarodniPoslanikView
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

        
        public virtual IList<TelefonView> Telefoni { get; set; }

        public virtual IList<OrganizacionaJedinicaView> JePredsednik { get; set; }
        public virtual IList<OrganizacionaJedinicaView> JeZamenik { get; set; }

        public virtual IList<JeClanView> JeClanOrganizacionihJedinica { get; set; }

        // public virtual IList<JePredlozioView> JePredlozioAkte { get; set; }

        // public virtual IList<JeSazvaloView> JeSazvaoSednice { get; set; }
        

        public NarodniPoslanikView()
        {
            Telefoni = new List<TelefonView>();
            JePredsednik = new List<OrganizacionaJedinicaView>();
            JeZamenik = new List<OrganizacionaJedinicaView>();

            JeClanOrganizacionihJedinica = new List<JeClanView>();

            // JePredlozioAkte = new List<JePredlozioView>();

            // JeSazvaoSednice = new List<JeSazvaloView>();
        }

        public NarodniPoslanikView(NarodniPoslanik narodniPoslanik)
        {
            Id = narodniPoslanik.Id;
            Jib = narodniPoslanik.Jib;
            Jmbg = narodniPoslanik.Jmbg;
            LicnoIme = narodniPoslanik.LicnoIme;
            ImeRoditelja = narodniPoslanik.ImeRoditelja;
            Prezime = narodniPoslanik.Prezime;
            DatumRodjenja = narodniPoslanik.DatumRodjenja;
            MestoRodjenja = narodniPoslanik.MestoRodjenja;
            IzbornaLista = narodniPoslanik.IzbornaLista;
            MestoStanovanja = narodniPoslanik.MestoStanovanja;
            AdresaStanovanja = narodniPoslanik.AdresaStanovanja;
        }
    }
}

