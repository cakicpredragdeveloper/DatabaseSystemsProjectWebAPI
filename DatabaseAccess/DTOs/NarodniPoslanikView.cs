using AutoMapper;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class NarodniPoslanikView
    {
        public int Id { get; protected set; }
        public int Jib { get; set; }
        public Int64 Jmbg { get; set; }
        public string LicnoIme { get; set; }
        public string ImeRoditelja { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MestoRodjenja { get; set; }
        public string IzbornaLista { get; set; }
        public string MestoStanovanja { get; set; }
        public string AdresaStanovanja { get; set; }

        public NarodniPoslanikView()
        { }

        public NarodniPoslanikView(NarodniPoslanik narodniPoslanik)
        {
            this.Id = narodniPoslanik.Id;
            this.Jib = narodniPoslanik.Jib;
            this.Jmbg = narodniPoslanik.Jmbg;
            this.LicnoIme = narodniPoslanik.LicnoIme;
            this.ImeRoditelja = narodniPoslanik.ImeRoditelja;
            this.Prezime = narodniPoslanik.Prezime;
            this.DatumRodjenja = narodniPoslanik.DatumRodjenja;
            this.MestoRodjenja = narodniPoslanik.MestoRodjenja;
            this.IzbornaLista = narodniPoslanik.IzbornaLista;
            this.MestoStanovanja = narodniPoslanik.MestoStanovanja;
            this.AdresaStanovanja = narodniPoslanik.AdresaStanovanja;
        }
    }
}
