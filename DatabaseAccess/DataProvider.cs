using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DatabaseAccess.DTOs;
using DatabaseAccess.Entities;
using NHibernate;

namespace DatabaseAccess
{
    public class DataProvider
    {

        #region NarodniPoslanik
        public static void CreateNarodniPoslanik(NarodniPoslanikView narodniPoslanikView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = new NarodniPoslanik()
                {
                    Jib = narodniPoslanikView.Jib,
                    Jmbg = narodniPoslanikView.Jmbg,
                    LicnoIme = narodniPoslanikView.LicnoIme,
                    ImeRoditelja = narodniPoslanikView.ImeRoditelja,
                    Prezime = narodniPoslanikView.Prezime,
                    DatumRodjenja = narodniPoslanikView.DatumRodjenja,
                    MestoRodjenja = narodniPoslanikView.MestoRodjenja,
                    IzbornaLista = narodniPoslanikView.IzbornaLista,
                    MestoStanovanja = narodniPoslanikView.MestoStanovanja,
                    AdresaStanovanja = narodniPoslanikView.AdresaStanovanja
                };

                session.Save(narodniPoslanik);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static NarodniPoslanikView ReadNarodniPoslanik(int narodniPoslanikId)
        {
            NarodniPoslanikView narodniPoslanikView;

            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(narodniPoslanikId);
                narodniPoslanikView = new NarodniPoslanikView(narodniPoslanik);

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return narodniPoslanikView;
        }

        public static List<NarodniPoslanikView> ReadNarodniPoslanici()
        {
            List<NarodniPoslanikView> narodniPoslaniciView = new List<NarodniPoslanikView>();
            
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<NarodniPoslanik> narodniPoslanici = from narodniPoslanik in session.Query<NarodniPoslanik>() select narodniPoslanik;

                foreach (NarodniPoslanik narodniPoslanik in narodniPoslanici)
                {
                    narodniPoslaniciView.Add(new NarodniPoslanikView(narodniPoslanik));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return narodniPoslaniciView;
        }

        public static NarodniPoslanikView UpdateNarodniPoslanik(int narodniPoslanikId, NarodniPoslanikView narodniPoslanikView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(narodniPoslanikId);

                narodniPoslanik.Jib =  narodniPoslanikView.Jib;
                narodniPoslanik.Jmbg =  narodniPoslanikView.Jmbg;
                narodniPoslanik.LicnoIme =  narodniPoslanikView.LicnoIme;
                narodniPoslanik.ImeRoditelja =  narodniPoslanikView.ImeRoditelja;
                narodniPoslanik.Prezime =  narodniPoslanikView.Prezime;
                narodniPoslanik.DatumRodjenja =  narodniPoslanikView.DatumRodjenja;
                narodniPoslanik.MestoRodjenja =  narodniPoslanikView.MestoRodjenja;
                narodniPoslanik.IzbornaLista =  narodniPoslanikView.IzbornaLista;
                narodniPoslanik.MestoStanovanja =  narodniPoslanikView.MestoStanovanja;
                narodniPoslanik.AdresaStanovanja =  narodniPoslanikView.AdresaStanovanja;

                session.Update(narodniPoslanik);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return narodniPoslanikView;
        }

        public static void DeleteNarodniPoslanik(int narodniPoslanikId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(narodniPoslanikId);

                session.Delete(narodniPoslanik);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static List<OrganizacionaJedinicaView> ReadNarodniPoslanikClanstva(int narodniPoslanikId)
        {
            List<OrganizacionaJedinicaView> organizacioneJediniceView = new List<OrganizacionaJedinicaView>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<JeClan> jeClanNiz = from jeClan in session.Query<JeClan>()
                                                            where jeClan.NarodniPoslanik.Id == narodniPoslanikId
                                                            select jeClan;

                foreach (JeClan jeClan in jeClanNiz)
                {
                    organizacioneJediniceView.Add(new OrganizacionaJedinicaView(jeClan.OrganizacionaJedinica));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return organizacioneJediniceView;
        }

        // public static List<AktView> ReadNarodniPoslanikPredlozeniAkti(int narodniPoslanikId)
        // {
        //     List<AktView> aktiView = new List<AktView>();

        //     try
        //     {
        //         ISession session = DataLayer.GetSession();

        //         IEnumerable<JePredlozio> jePredlozioNiz = from jePredlozio in session.Query<JePredlozio>()
        //                                                     where jePredlozio.NarodniPoslanik.Id == narodniPoslanikId
        //                                                     select jePredlozio;

        //         foreach (JePredlozio jePredlozio in jePredlozioNiz)
        //         {
        //             aktiView.Add(new AktView(jePredlozio.Akt));
        //         }

        //         session.Close();
        //     }
        //     catch (Exception exception)
        //     {
        //         throw exception;
        //     }

        //     return aktiView;
        // }

        #endregion
 
        #region StalnoZaposlen
        public static void CreateStalnoZaposlen(StalnoZaposlenView stalnoZaposlenView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                StalnoZaposlen stalnoZaposlen = new StalnoZaposlen()
                {
                    Jib = stalnoZaposlenView.Jib,
                    Jmbg = stalnoZaposlenView.Jmbg,
                    LicnoIme = stalnoZaposlenView.LicnoIme,
                    ImeRoditelja = stalnoZaposlenView.ImeRoditelja,
                    Prezime = stalnoZaposlenView.Prezime,
                    DatumRodjenja = stalnoZaposlenView.DatumRodjenja,
                    MestoRodjenja = stalnoZaposlenView.MestoRodjenja,
                    IzbornaLista = stalnoZaposlenView.IzbornaLista,
                    MestoStanovanja = stalnoZaposlenView.MestoStanovanja,
                    AdresaStanovanja = stalnoZaposlenView.AdresaStanovanja,
                    Brk = stalnoZaposlenView.Brk,
                    RsGodine = stalnoZaposlenView.RsGodine,
                    RsMeseci = stalnoZaposlenView.RsMeseci,
                    RsDani = stalnoZaposlenView.RsDani,
                    ImeFirme = stalnoZaposlenView.ImeFirme
                };

                session.Save(stalnoZaposlen);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static StalnoZaposlenView ReadStalnoZaposlen(int stalnoZaposlenId)
        {
            StalnoZaposlenView stalnoZaposlenView;

            try
            {
                ISession session = DataLayer.GetSession();

                StalnoZaposlen stalnoZaposlen = session.Load<StalnoZaposlen>(stalnoZaposlenId);
                stalnoZaposlenView = new StalnoZaposlenView(stalnoZaposlen);

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return stalnoZaposlenView;
        }

        public static List<StalnoZaposlenView> ReadStalnoZaposleni()
        {
            List<StalnoZaposlenView> stalnoZaposleniView = new List<StalnoZaposlenView>();
            
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<StalnoZaposlen> stalnoZaposleni = from stalnoZaposlen in session.Query<StalnoZaposlen>() select stalnoZaposlen;

                foreach (StalnoZaposlen stalnoZaposlen in stalnoZaposleni)
                {
                    stalnoZaposleniView.Add(new StalnoZaposlenView(stalnoZaposlen));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return stalnoZaposleniView;
        }

        public static StalnoZaposlenView UpdateStalnoZaposlen(int stalnoZaposlenId, StalnoZaposlenView stalnoZaposlenView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                StalnoZaposlen stalnoZaposlen = session.Load<StalnoZaposlen>(stalnoZaposlenId);

                stalnoZaposlen.Jib =  stalnoZaposlenView.Jib;
                stalnoZaposlen.Jmbg =  stalnoZaposlenView.Jmbg;
                stalnoZaposlen.LicnoIme =  stalnoZaposlenView.LicnoIme;
                stalnoZaposlen.ImeRoditelja =  stalnoZaposlenView.ImeRoditelja;
                stalnoZaposlen.Prezime =  stalnoZaposlenView.Prezime;
                stalnoZaposlen.DatumRodjenja =  stalnoZaposlenView.DatumRodjenja;
                stalnoZaposlen.MestoRodjenja =  stalnoZaposlenView.MestoRodjenja;
                stalnoZaposlen.IzbornaLista =  stalnoZaposlenView.IzbornaLista;
                stalnoZaposlen.MestoStanovanja =  stalnoZaposlenView.MestoStanovanja;
                stalnoZaposlen.AdresaStanovanja =  stalnoZaposlenView.AdresaStanovanja;
                stalnoZaposlen.Brk = stalnoZaposlenView.Brk;
                stalnoZaposlen.RsGodine = stalnoZaposlenView.RsGodine;
                stalnoZaposlen.RsMeseci = stalnoZaposlenView.RsMeseci;
                stalnoZaposlen.RsDani = stalnoZaposlenView.RsDani;
                stalnoZaposlen.ImeFirme = stalnoZaposlenView.ImeFirme;

                session.Update(stalnoZaposlen);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return stalnoZaposlenView;
        }

        public static void DeleteStalnoZaposlen(int stalnoZaposlenId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                StalnoZaposlen stalnoZaposlen = session.Load<StalnoZaposlen>(stalnoZaposlenId);

                session.Delete(stalnoZaposlen);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

     
        #endregion

        #region Telefon
        public static void CreateTelefon(int narodoniPoslanikId, TelefonView telefonView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(narodoniPoslanikId);

                Telefon telefon = new Telefon()
                {
                    BrojTelefona = telefonView.BrojTelefona,
                    NarodniPoslanik = narodniPoslanik
                };

                session.Save(telefon);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static TelefonView ReadTelefon(int telefonId)
        {
            TelefonView telefonView;

            try
            {
                ISession session = DataLayer.GetSession();

                Telefon telefon = session.Load<Telefon>(telefonId);
                telefonView = new TelefonView(telefon);

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return telefonView;
        }

        public static List<TelefonView> ReadTelefoni(int narodniPoslanikId)
        {
            List<TelefonView> telefoniView = new List<TelefonView>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<Telefon> telefoni = from telefon in session.Query<Telefon>()
                                                where telefon.NarodniPoslanik.Id == narodniPoslanikId
                                                select telefon;

                foreach (Telefon tel in telefoni)
                {
                    var telView = new TelefonView(tel)
                    {
                        NarodniPoslanik = new NarodniPoslanikView(tel.NarodniPoslanik)
                    };

                    telefoniView.Add(telView);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }

            return telefoniView;
        }

        public static TelefonView UpdateTelefon(int telefonId, TelefonView telefonView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                Telefon telefon = session.Load<Telefon>(telefonId);

                telefon.BrojTelefona = telefonView.BrojTelefona;

                session.Update(telefon);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return telefonView;
        }

        public static void DeleteTelefon(int telefonId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                Telefon telefon = session.Load<Telefon>(telefonId);

                session.Delete(telefon);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion

        #region PoslanickaGrupa
        public static void CreatePoslanickaGrupa(PoslanickaGrupaView poslanickaGrupaView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                // NarodniPoslanik predsednik = session.Load<NarodniPoslanik>(poslanickaGrupaView.)

                // TODO

                PoslanickaGrupa poslanickaGrupa = new PoslanickaGrupa()
                {
                    Tip = poslanickaGrupaView.Tip,
                    Naziv = poslanickaGrupaView.Naziv, 
                    TipRadnogTela =  poslanickaGrupaView.TipRadnogTela,
                    // Predsednik
                    // Zamenik
                };

                session.Save(poslanickaGrupa);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static PoslanickaGrupaView ReadPoslanickaGrupa(int poslanickaGrupaId)
        {
            PoslanickaGrupaView poslanickaGrupaView;

            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(poslanickaGrupaId);
                poslanickaGrupaView = new PoslanickaGrupaView(poslanickaGrupa);

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return poslanickaGrupaView;
        }

        public static List<PoslanickaGrupaView> ReadPoslanickeGrupe()
        {
            List<PoslanickaGrupaView> poslanickeGrupeView = new List<PoslanickaGrupaView>();
            
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<PoslanickaGrupa> poslanickeGrupe = from poslanickaGrupa in session.Query<PoslanickaGrupa>() select poslanickaGrupa;

                foreach (PoslanickaGrupa poslanickaGrupa in poslanickeGrupe)
                {
                    poslanickeGrupeView.Add(new PoslanickaGrupaView(poslanickaGrupa));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return poslanickeGrupeView;
        }

        public static PoslanickaGrupaView UpdatePoslanickaGrupa(PoslanickaGrupaView poslanickaGrupaView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(poslanickaGrupaView.Id);

                // TODO update Predsednik i zamenik
                poslanickaGrupa.Naziv = poslanickaGrupaView.Naziv;

                session.Update(poslanickaGrupa);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return poslanickaGrupaView;
        }

        public static void DeletePoslanickaGrupa(int poslanickaGrupaId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(poslanickaGrupaId);

                session.Delete(poslanickaGrupa);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion

        #region RadnoTelo
        public static void CreateRadnoTelo(RadnoTeloView radnoTeloView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                // NarodniPoslanik predsednik = session.Load<NarodniPoslanik>(poslanickaGrupaView.)

                // TODO

                RadnoTelo radnoTelo = new RadnoTelo()
                {
                    Tip = radnoTeloView.Tip,
                    Naziv = radnoTeloView.Naziv, 
                    TipRadnogTela =  radnoTeloView.TipRadnogTela,
                    // Predsednik
                    // Zamenik
                };

                session.Save(radnoTelo);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static RadnoTeloView ReadRadnoTelo(int radnoTeloId)
        {
            RadnoTeloView radnoTeloView;

            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(radnoTeloId);
                radnoTeloView = new RadnoTeloView(radnoTelo);

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return radnoTeloView;
        }

        public static List<RadnoTeloView> ReadRadnaTela()
        {
            List<RadnoTeloView> radnaTelaView = new List<RadnoTeloView>();
            
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<RadnoTelo> radnaTela = from radnoTelo in session.Query<RadnoTelo>() select radnoTelo;

                foreach (RadnoTelo radnoTelo in radnaTela)
                {
                    radnaTelaView.Add(new RadnoTeloView(radnoTelo));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return radnaTelaView;
        }


        public static RadnoTeloView UpdateRadnoTelo(RadnoTeloView radnoTeloView)
        {
           try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(radnoTeloView.Id);

                // TODO update Predsednik i zamenik
                radnoTelo.Naziv = radnoTeloView.Naziv;

                session.Update(radnoTelo);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return radnoTeloView;
        }

        public static void DeleteRadnoTelo(int radnoTeloId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(radnoTeloId);

                session.Delete(radnoTelo);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion
        
    }
}
