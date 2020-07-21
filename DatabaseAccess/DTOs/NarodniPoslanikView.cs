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

        public NarodniPoslanikView()
        {
            Telefoni = new List<TelefonView>();
            JePredsednik = new List<OrganizacionaJedinicaView>();
            JeZamenik = new List<OrganizacionaJedinicaView>();
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

        public NarodniPoslanikView(
            NarodniPoslanik narodniPoslanik, 
            IList<OrganizacionaJedinica> jePredsednik, 
            IList<OrganizacionaJedinica> jeZamenik,
            IList<Telefon> telefoni)
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

            if(jePredsednik != null)
            {
                JePredsednik = new List<OrganizacionaJedinicaView>();
                foreach( OrganizacionaJedinica organizacionaJedinica in jePredsednik )
                {
                    JePredsednik.Add(new OrganizacionaJedinicaView(organizacionaJedinica));
                }
            }

            if(jeZamenik != null)
            {
                JeZamenik = new List<OrganizacionaJedinicaView>();
                foreach( OrganizacionaJedinica organizacionaJedinica in jeZamenik )
                {
                    JeZamenik.Add(new OrganizacionaJedinicaView(organizacionaJedinica));
                }
            }

            if(telefoni != null)
            {
                Telefoni = new List<TelefonView>();
                foreach( Telefon telefon in telefoni )
                {
                    Telefoni.Add(new TelefonView(telefon));
                }
            }
        }
    }
}

