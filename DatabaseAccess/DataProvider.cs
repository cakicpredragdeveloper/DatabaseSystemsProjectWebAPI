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

        public static NarodniPoslanikView ReadNarodniPoslanik(int narodniPoslanikId, bool withTelefoni)
        {
            NarodniPoslanikView narodniPoslanikView;

            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(narodniPoslanikId);

                if(withTelefoni == true)
                {
                    narodniPoslanikView = 
                        new NarodniPoslanikView(narodniPoslanik, narodniPoslanik.JePredsednik, narodniPoslanik.JeZamenik, narodniPoslanik.Telefoni);
                }
                else
                {
                    narodniPoslanikView = 
                        new NarodniPoslanikView(narodniPoslanik, narodniPoslanik.JePredsednik, narodniPoslanik.JeZamenik, null);

                }

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

        public static List<AktNarodnihPoslanikaView> ReadNarodniPoslanikPredlozeniAkti(int narodniPoslanikId)
        {
            List<AktNarodnihPoslanikaView> aktiView = new List<AktNarodnihPoslanikaView>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<JePredlozio> jePredlozioNiz = from jePredlozio in session.Query<JePredlozio>()
                                                            where jePredlozio.NarodniPoslanik.Id == narodniPoslanikId
                                                            select jePredlozio;

                foreach (JePredlozio jePredlozio in jePredlozioNiz)
                {
                    aktiView.Add(new AktNarodnihPoslanikaView(jePredlozio.Akt));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return aktiView;
        }

        public static List<SednicaView> ReadNarodniPoslanikSazvaneSednice(int narodniPoslanikId)
        {
            List<SednicaView> sazvaneSedniceView = new List<SednicaView>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<JeSazvalo> jeSazvaloNiz = from jeSazvalo in session.Query<JeSazvalo>()
                                                            where jeSazvalo.NarodniPoslanik.Id == narodniPoslanikId
                                                            select jeSazvalo;

                foreach (JeSazvalo jeSazvalo in jeSazvaloNiz)
                {
                    sazvaneSedniceView.Add(new SednicaView(jeSazvalo.Sednica));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return sazvaneSedniceView;
        }

        public static void CreateNarodniPoslanikSazoviSednicu(int narodniPoslanikId, int sednicaId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(narodniPoslanikId);
                VanrednaSednica sednica = session.Load<VanrednaSednica>(sednicaId);

                JeSazvalo jeSazvalo = new JeSazvalo();

                jeSazvalo.NarodniPoslanik = narodniPoslanik;
                jeSazvalo.Sednica = sednica;

                session.Save(jeSazvalo);
        
                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void CreateNarodniPoslanikPredloziAkt(int narodniPoslanikId, int aktId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(narodniPoslanikId);
                AktNarodnihPoslanika akt = session.Load<AktNarodnihPoslanika>(aktId);

                JePredlozio jePredlozio = new JePredlozio();

                jePredlozio.NarodniPoslanik = narodniPoslanik;
                jePredlozio.Akt = akt;

                session.Save(jePredlozio);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void DeleteNarodniPoslanikClanstvo(int narodniPoslanikId, int organizacionaJedinicaId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                List<JeClan> clanstva = session.Query<JeClan>()
                                                    .Where(jeClan => jeClan.NarodniPoslanik.Id == narodniPoslanikId &&
                                                             jeClan.OrganizacionaJedinica.Id == organizacionaJedinicaId).ToList();

                if(clanstva.Count == 1)
                {
                    session.Delete(clanstva[0]);
                }

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void DeleteNarodniPoslanikPredlogAkta(int narodniPoslanikId, int aktId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                List<JePredlozio> predlozi = session.Query<JePredlozio>()
                                    .Where(JePredlozio => JePredlozio.NarodniPoslanik.Id == narodniPoslanikId &&
                                                             JePredlozio.Akt.Id == aktId).ToList();

                if(predlozi.Count == 1)
                {
                    session.Delete(predlozi[0]);
                }

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void CreateNarodniPoslanikPostaniClan(int narodniPoslanikId, int organizacionaJedinicaId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(narodniPoslanikId);
                OrganizacionaJedinica organizacionaJedinica = session.Load<OrganizacionaJedinica>(organizacionaJedinicaId);

                JeClan jeClan = new JeClan();

                jeClan.NarodniPoslanik = narodniPoslanik;
                jeClan.OrganizacionaJedinica = organizacionaJedinica;

                session.Save(jeClan);
        
                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void DeleteNarodniPoslanikSazivanjeSednice(int narodniPoslanikId, int sednicaId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                List<JeSazvalo> sazivi = session.Query<JeSazvalo>()
                                    .Where(JeSazvalo => JeSazvalo.NarodniPoslanik.Id == narodniPoslanikId &&
                                                             JeSazvalo.Sednica.Id == sednicaId).ToList();

                if(sazivi.Count == 1)
                {
                    session.Delete(sazivi[0]);
                }

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

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

        public static StalnoZaposlenView ReadStalnoZaposlen(int stalnoZaposlenId, bool withTelefoni)
        {
            StalnoZaposlenView stalnoZaposlenView;

            try
            {
                ISession session = DataLayer.GetSession();

                StalnoZaposlen stalnoZaposlen = session.Load<StalnoZaposlen>(stalnoZaposlenId);

                if(withTelefoni == true)
                {
                    stalnoZaposlenView = 
                        new StalnoZaposlenView(stalnoZaposlen, stalnoZaposlen.JePredsednik, stalnoZaposlen.JeZamenik, stalnoZaposlen.Telefoni);
                }
                else
                {
                    stalnoZaposlenView = 
                        new StalnoZaposlenView(stalnoZaposlen, stalnoZaposlen.JePredsednik, stalnoZaposlen.JeZamenik, null);
                }


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
                telefonView = new TelefonView(telefon, telefon.NarodniPoslanik);

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

                foreach (Telefon telefon in telefoni)
                {
                    telefoniView.Add(new TelefonView(telefon));
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
        public static void CreatePoslanickaGrupa(PoslanickaGrupaPost poslanickaGrupaPost)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik predsednik = session.Load<NarodniPoslanik>(poslanickaGrupaPost.PredsednikId);
                NarodniPoslanik zamenik = session.Load<NarodniPoslanik>(poslanickaGrupaPost.ZamenikId);

                PoslanickaGrupa poslanickaGrupa = new PoslanickaGrupa()
                {
                    Naziv = poslanickaGrupaPost.Naziv,
                    Predsednik = predsednik,
                    Zamenik = zamenik,
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
                poslanickaGrupaView = new PoslanickaGrupaView(poslanickaGrupa, poslanickaGrupa.Predsednik, poslanickaGrupa.Zamenik);

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

        public static PoslanickaGrupaView UpdatePoslanickaGrupa(int poslanickaGrupaId, PoslanickaGrupaView poslanickaGrupaView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(poslanickaGrupaId);

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

        public static List<NarodniPoslanikView> ReadPoslanickaGrupaClanovi(int poslanickaGrupaId)
        {
            List<NarodniPoslanikView> narodniPoslaniciView = new List<NarodniPoslanikView>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<JeClan> jeClanNiz = from jeClan in session.Query<JeClan>()
                                                            where jeClan.OrganizacionaJedinica.Id == poslanickaGrupaId
                                                            select jeClan;

                foreach (JeClan jeClan in jeClanNiz)
                {
                    narodniPoslaniciView.Add(new NarodniPoslanikView(jeClan.NarodniPoslanik));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return narodniPoslaniciView;
        }

        public static List<SluzbenaProstorijaView> ReadPoslanickaGrupaSluzbeneProstorije(int poslanickaGrupaId)
        {
            List<SluzbenaProstorijaView> sluzbeneProstorijeView = new List<SluzbenaProstorijaView>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<JeDodeljena> jeDodeljenaNiz = from jeDodeljena in session.Query<JeDodeljena>()
                                                            where jeDodeljena.OrganizacionaJedinica.Id == poslanickaGrupaId
                                                            select jeDodeljena;

                foreach (JeDodeljena jeDodeljena in jeDodeljenaNiz)
                {
                    sluzbeneProstorijeView.Add(new SluzbenaProstorijaView(jeDodeljena.SluzbenaProstorija));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return sluzbeneProstorijeView;
        }

        public static PoslanickaGrupaView UpdatePoslanickaGrupaPredsednik(int poslanickaGrupaId, int predsednikId)
        {
            PoslanickaGrupaView poslanickaGrupaView;

            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(poslanickaGrupaId);
                NarodniPoslanik predsednik = session.Load<NarodniPoslanik>(predsednikId);

                poslanickaGrupa.Predsednik = predsednik;

                session.Update(poslanickaGrupa);

                poslanickaGrupaView = new PoslanickaGrupaView(poslanickaGrupa, poslanickaGrupa.Predsednik, poslanickaGrupa.Zamenik);
                
                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return poslanickaGrupaView;
        }

        public static PoslanickaGrupaView UpdatePoslanickaGrupaZamenik(int poslanickaGrupaId, int zamenikId)
        {
            PoslanickaGrupaView poslanickaGrupaView;
            
            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(poslanickaGrupaId);
                NarodniPoslanik zamenik = session.Load<NarodniPoslanik>(zamenikId);

                poslanickaGrupa.Zamenik = zamenik;

                session.Update(poslanickaGrupa);

                poslanickaGrupaView = new PoslanickaGrupaView(poslanickaGrupa, poslanickaGrupa.Predsednik, poslanickaGrupa.Zamenik);
                
                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return poslanickaGrupaView;
        }

        public static void AddPoslanickaGrupaSluzbenaProstorija(int poslanickaGrupaId, int sluzbenaProstorijaId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(poslanickaGrupaId);
                SluzbenaProstorija sluzbenaProstorija = session.Load<SluzbenaProstorija>(sluzbenaProstorijaId);

                // proveravamo da li je poslanickoj grupi vec dodeljena prostorija

                bool vecDodeljena = session.Query<JeDodeljena>()
                                .Any(jd => jd.SluzbenaProstorija.Id == sluzbenaProstorijaId && jd.OrganizacionaJedinica.Id == poslanickaGrupaId);

                if(!vecDodeljena)
                {
                    JeDodeljena jeDodeljena = new JeDodeljena();
                    jeDodeljena.OrganizacionaJedinica = poslanickaGrupa;
                    jeDodeljena.SluzbenaProstorija = sluzbenaProstorija;

                    session.Save(jeDodeljena);
                }

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static bool DeletePoslanickaGrupaSluzbenaProstorija(int poslanickaGrupaId, int sluzbenaProstorijaId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                //na pocetku proveravamo da li je poslanickoj grupi dodeljena odgovarajuca sluzbena prostorija

                bool daLiJeDodeljena = session.Query<JeDodeljena>()
                                .Any(jd => jd.SluzbenaProstorija.Id == sluzbenaProstorijaId && jd.OrganizacionaJedinica.Id == poslanickaGrupaId);

                if(daLiJeDodeljena)
                {
                    JeDodeljena jeDodeljena = session.Query<JeDodeljena>()
                            .FirstOrDefault(jd => jd.OrganizacionaJedinica.Id == poslanickaGrupaId && jd.SluzbenaProstorija.Id == sluzbenaProstorijaId);

                    PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(poslanickaGrupaId);

                    poslanickaGrupa.JeDodeljenaSluzbeneProstorije.Remove(jeDodeljena);

                    session.Delete(jeDodeljena);
                    session.Flush();
                    session.Close();
                    return true;
                }

                session.Close();
                return false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion

        #region RadnoTelo
        public static void CreateRadnoTelo(RadnoTeloPost radnoTeloPost)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik predsednik = session.Load<NarodniPoslanik>(radnoTeloPost.PredsednikId);
                NarodniPoslanik zamenik = session.Load<NarodniPoslanik>(radnoTeloPost.ZamenikId);

                RadnoTelo radnoTelo = new RadnoTelo()
                {
                    TipRadnogTela =  radnoTeloPost.TipRadnogTela,
                    Predsednik = predsednik,
                    Zamenik = zamenik
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
                radnoTeloView = new RadnoTeloView(radnoTelo, radnoTelo.Predsednik, radnoTelo.Zamenik);

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


        public static RadnoTeloView UpdateRadnoTelo(int radnoTeloId, RadnoTeloView radnoTeloView)
        {
           try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(radnoTeloId);

                // TODO update Predsednik i zamenik
                radnoTelo.TipRadnogTela = radnoTeloView.TipRadnogTela;

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
        
        public static List<NarodniPoslanikView> ReadRadnoTeloClanovi(int radnoTeloId)
        {
            List<NarodniPoslanikView> narodniPoslaniciView = new List<NarodniPoslanikView>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<JeClan> jeClanNiz = from jeClan in session.Query<JeClan>()
                                                            where jeClan.OrganizacionaJedinica.Id == radnoTeloId
                                                            select jeClan;

                foreach (JeClan jeClan in jeClanNiz)
                {
                    narodniPoslaniciView.Add(new NarodniPoslanikView(jeClan.NarodniPoslanik));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return narodniPoslaniciView;
        }

        public static List<SluzbenaProstorijaView> ReadRadnoTeloSluzbeneProstorije(int radnoTeloId)
        {
            List<SluzbenaProstorijaView> sluzbeneProstorijeView = new List<SluzbenaProstorijaView>();

            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<JeDodeljena> jeDodeljenaNiz = from jeDodeljena in session.Query<JeDodeljena>()
                                                            where jeDodeljena.OrganizacionaJedinica.Id == radnoTeloId
                                                            select jeDodeljena;

                foreach (JeDodeljena jeDodeljena in jeDodeljenaNiz)
                {
                    sluzbeneProstorijeView.Add(new SluzbenaProstorijaView(jeDodeljena.SluzbenaProstorija));
                }

                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return sluzbeneProstorijeView;
        }

        public static bool AddRadnoTeloSluzbenaProstorija(int radnoTeloId, int sluzbenaProstorijaId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(radnoTeloId);
                SluzbenaProstorija sluzbenaProstorija = session.Load<SluzbenaProstorija>(sluzbenaProstorijaId);

                // posto po uslovu zadatka radnom telu moze biti dodeljena samo jedna sluzbena prostorija
                // to moramo ispitati, tj omogucujemo dodeljivanje samo ako je broj liste dodeljenih prostorija jednak 0

                if (radnoTelo.JeDodeljenaSluzbeneProstorije.Count == 0)
                {
                    JeDodeljena jeDodeljena = new JeDodeljena();
                    jeDodeljena.OrganizacionaJedinica = radnoTelo;
                    jeDodeljena.SluzbenaProstorija = sluzbenaProstorija;

                    session.Save(jeDodeljena);

                    session.Flush();
                    session.Close();
                    return true;
                }

                session.Close();
                return false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        
        public static bool DeleteRadnoTeloSluzbenaProstorija(int radnoTeloId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(radnoTeloId);

                // radnom telu moze biti dodeljena samo jedna sluzbena prostorija, ta provera je implementirana
                // kod dodavanja, sada slicnu proveru vrsimo i ovde

                if(radnoTelo.JeDodeljenaSluzbeneProstorije.Count == 1)
                {
                    JeDodeljena jeDodeljena = radnoTelo.JeDodeljenaSluzbeneProstorije[0];
                    radnoTelo.JeDodeljenaSluzbeneProstorije.Remove(jeDodeljena);

                    session.Delete(jeDodeljena);
                    session.Flush();
                    session.Close();
                    return true;
                }

                session.Close();
                return false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static RadnoTeloView UpdateRadnoTeloPredsednik(int radnoTeloId, int predsednikId)
        {
            RadnoTeloView radnoTeloView;

            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(radnoTeloId);
                NarodniPoslanik predsednik = session.Load<NarodniPoslanik>(predsednikId);

                radnoTelo.Predsednik = predsednik;

                session.Update(radnoTelo);
            
                radnoTeloView = new RadnoTeloView(radnoTelo, radnoTelo.Predsednik, radnoTelo.Zamenik);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return radnoTeloView;
        }

        public static RadnoTeloView UpdateRadnoTeloZamenik(int radnoTeloId, int zamenikId)
        {
            RadnoTeloView radnoTeloView;
            
            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(radnoTeloId);
                NarodniPoslanik zamenik = session.Load<NarodniPoslanik>(zamenikId);

                radnoTelo.Zamenik = zamenik;

                session.Update(radnoTelo);
            
                radnoTeloView = new RadnoTeloView(radnoTelo, radnoTelo.Predsednik, radnoTelo.Zamenik);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return radnoTeloView;
        }
        
        #endregion
        
        #region Akta

        #region AktNarodnihPoslanika
        public static AktNarodnihPoslanikaView VratiAktNarodnihPoslanika(int Id)
        {
            AktNarodnihPoslanikaView aktZaVracanje = new AktNarodnihPoslanikaView();
            try
            {
                ISession session = DataLayer.GetSession();

                AktNarodnihPoslanika akt = session.Load<AktNarodnihPoslanika>(Id);

                aktZaVracanje.Id = akt.Id;
                aktZaVracanje.TipAkta = akt.TipAkta;

                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return aktZaVracanje;
        }

        public static List<NarodniPoslanikView> VratiPredlagace(int Id)
        {
            List<NarodniPoslanikView> predlagaciViews = new List<NarodniPoslanikView>();

            try
            {
                ISession session = DataLayer.GetSession();

                AktNarodnihPoslanika akt = session.Load<AktNarodnihPoslanika>(Id);

                List<NarodniPoslanik> predlagaci = session.Query<NarodniPoslanik>()
                                                            .Where(p => p.JePredlozioAkte.Any<JePredlozio>(jp => jp.Akt.Id == Id))
                                                            .ToList();

                foreach (var predlagac in predlagaci)
                {
                    predlagaciViews.Add(new NarodniPoslanikView(predlagac));
                }

                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }


            return predlagaciViews;
        }

        public static void DodajAktNarodnihPoslanika(AktNarodnihPoslanikaView akt)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktNarodnihPoslanika aktNarodnihPoslanika = new AktNarodnihPoslanika()
                {
                    TipAkta = akt.TipAkta
                };

                session.Save(aktNarodnihPoslanika);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void AzurirajAktNarodnihPoslanika(AktNarodnihPoslanikaView akt)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktNarodnihPoslanika aktNarodnihPoslanika = session.Load<AktNarodnihPoslanika>(akt.Id);

                aktNarodnihPoslanika.TipAkta = akt.TipAkta;

                session.Save(aktNarodnihPoslanika);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiAktNarodnihPoslanika(int Id)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktNarodnihPoslanika aktNarodnihPoslanika = session.Load<AktNarodnihPoslanika>(Id);

                session.Delete(aktNarodnihPoslanika);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region AktViseOd1500Biraca
        public static AktViseOd1500BiracaView VratiAktViseOd1500Biraca(int Id)
        {
            AktViseOd1500BiracaView aktZaVracanje = new AktViseOd1500BiracaView();
            try
            {
                ISession session = DataLayer.GetSession();

                AktViseOd1500Biraca akt = session.Load<AktViseOd1500Biraca>(Id);

                aktZaVracanje.Id = akt.Id;
                aktZaVracanje.TipAkta = akt.TipAkta;
                aktZaVracanje.BrojBiraca = akt.BrojBiraca;

                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return aktZaVracanje;
        }

        public static void DodajAktViseOd1500Biraca(AktViseOd1500BiracaView akt)
        {
            ISession session = DataLayer.GetSession();

            AktViseOd1500Biraca aktViseOd1500Biraca = new AktViseOd1500Biraca()
            {
                TipAkta = akt.TipAkta,
                BrojBiraca = akt.BrojBiraca
            };

            session.Save(aktViseOd1500Biraca);
            session.Flush();
            session.Close();
        }

        public static void AzurirajAktViseOd1500Biraca(AktViseOd1500BiracaView akt)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktViseOd1500Biraca aktViseOd1500Biraca = session.Load<AktViseOd1500Biraca>(akt.Id);

                aktViseOd1500Biraca.TipAkta = akt.TipAkta;
                aktViseOd1500Biraca.BrojBiraca = akt.BrojBiraca;

                session.Save(aktViseOd1500Biraca);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiAktViseOd1500Biraca(int Id)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktViseOd1500Biraca aktViseOd1500Biraca = session.Load<AktViseOd1500Biraca>(Id);

                session.Delete(aktViseOd1500Biraca);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region AktVlade
        public static AktVladeView VratiAktVlade(int Id)
        {
            AktVladeView aktZaVracanje = new AktVladeView();
            try
            {
                ISession session = DataLayer.GetSession();

                AktVlade akt = session.Load<AktVlade>(Id);

                aktZaVracanje.Id = akt.Id;
                aktZaVracanje.TipAkta = akt.TipAkta;

                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return aktZaVracanje;
        }

        public static void DodajAktVlade(AktVladeView akt)
        {
            ISession session = DataLayer.GetSession();

            AktVlade aktVlade = new AktVlade()
            {
                TipAkta = akt.TipAkta
            };

            session.Save(aktVlade);
            session.Flush();
            session.Close();
        }

        public static void AzurirajAktVlade(AktVladeView akt)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktVlade aktVlade = session.Load<AktVlade>(akt.Id);

                aktVlade.TipAkta = akt.TipAkta;

                session.Save(aktVlade);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiAktVlade(int Id)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktVlade aktVlade = session.Load<AktVlade>(Id);

                session.Delete(aktVlade);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #endregion

        #region SluzbeneProstorije

        public static List<SluzbenaProstorijaView> ReadSluzbeneProstorije()
        {
            List<SluzbenaProstorijaView> sluzbeneProstorije = new List<SluzbenaProstorijaView>();
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<SluzbenaProstorija> prostorije = session.Query<SluzbenaProstorija>()
                                                             .ToList();

                foreach (var prostorija in prostorije)
                {
                    sluzbeneProstorije.Add(new SluzbenaProstorijaView(prostorija));
                }

                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return sluzbeneProstorije;
        }

        public static void CreateSluzbenaProstorija(SluzbenaProstorijaView sluzbenaProstorijaView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                SluzbenaProstorija sluzbenaProstorija = new SluzbenaProstorija();
                sluzbenaProstorija.Sprat = sluzbenaProstorijaView.Sprat;
                sluzbenaProstorija.Broj = sluzbenaProstorijaView.Broj;

                session.Save(sluzbenaProstorija);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SluzbenaProstorijaView ReadSluzbenaProstorija(int Id)
        {
            SluzbenaProstorijaView sluzbenaProstorijaView;
            try
            {
                ISession session = DataLayer.GetSession();

                SluzbenaProstorija sluzbenaProstorija = session.Load<SluzbenaProstorija>(Id);

                sluzbenaProstorijaView = new SluzbenaProstorijaView(sluzbenaProstorija);
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return sluzbenaProstorijaView;
        }

        public static void UpdateSluzbenaProstorija(SluzbenaProstorijaView sluzbenaProstorijaView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                SluzbenaProstorija sluzbenaProstorija = session.Load<SluzbenaProstorija>(sluzbenaProstorijaView.Id);

                sluzbenaProstorija.Sprat = sluzbenaProstorijaView.Sprat;
                sluzbenaProstorija.Broj = sluzbenaProstorijaView.Broj;

                session.Save(sluzbenaProstorija);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<OrganizacionaJedinicaView> ReadOrgaznizacioneJedinice(int Id)
        {
            List<OrganizacionaJedinicaView> organizacioneJediniceViews = new List<OrganizacionaJedinicaView>();
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<OrganizacionaJedinica> organizacioneJedinice = session.Query<OrganizacionaJedinica>()
                                                    .Where(o => o.JeDodeljenaSluzbeneProstorije.Any<JeDodeljena>(jd => jd.SluzbenaProstorija.Id == Id))
                                                    .ToList();

                foreach( var organizacionaJediinica in organizacioneJedinice)
                {
                    organizacioneJediniceViews.Add(new OrganizacionaJedinicaView(organizacionaJediinica));
                }

                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return organizacioneJediniceViews;
        }

        public static void DeleteSluzbenaProstorija(int Id)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                SluzbenaProstorija sluzbenaProstorija = session.Load<SluzbenaProstorija>(Id);

                session.Delete(sluzbenaProstorija);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Sednice

        public static List<SednicaView> ReadSednice()
        {
            List<SednicaView> sedniceViews = new List<SednicaView>();
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<Sednica> sednice= session.Query<Sednica>().ToList();

                foreach(var sednica in sednice)
                {
                    sedniceViews.Add(new SednicaView(sednica));
                }

                session.Close();
            }
            catch(Exception)
            {
                throw;
            }

            return sedniceViews;
        }

        public static List<RedovnaSednicaView> ReadRedovneSednice()
        {
            List<RedovnaSednicaView> sedniceViews = new List<RedovnaSednicaView>();
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<RedovnaSednica> sednice = session.Query<RedovnaSednica>().ToList();

                foreach (var sednica in sednice)
                {
                    sedniceViews.Add(new RedovnaSednicaView(sednica));
                }

                session.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return sedniceViews;
        }

        public static RedovnaSednicaView ReadRedovnaSednica(int Id)
        {
            RedovnaSednicaView redovnaSednica;
            try
            {
                ISession session = DataLayer.GetSession();

                RedovnaSednica sednica = session.Load<RedovnaSednica>(Id);

                redovnaSednica = new RedovnaSednicaView(sednica);
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return redovnaSednica;
        }
        public static void CreateRedovnaSednica(RedovnaSednicaView redovnaSednica)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RedovnaSednica sednica = new RedovnaSednica();
                sednica.BrojSaziva = redovnaSednica.BrojSaziva;
                sednica.BrojZasedanja = redovnaSednica.BrojZasedanja;
                sednica.DatumPocetka = redovnaSednica.DatumPocetka;
                sednica.DatumZavrsetka = redovnaSednica.DatumZavrsetka;


                session.Save(sednica);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdateRedovnaSednica(RedovnaSednicaView redovnaSednica)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RedovnaSednica sednica = session.Load<RedovnaSednica>(redovnaSednica.Id);

                sednica.BrojSaziva = redovnaSednica.BrojSaziva;
                sednica.BrojZasedanja = redovnaSednica.BrojZasedanja;
                sednica.DatumPocetka = redovnaSednica.DatumPocetka;
                sednica.DatumZavrsetka = redovnaSednica.DatumZavrsetka;


                session.Save(sednica);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DeleteRedovnaSednica(int Id)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RedovnaSednica sednica = session.Load<RedovnaSednica>(Id);

                session.Delete(sednica);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<VanrednaSednicaView> ReadVanredneSednice()
        {
            List<VanrednaSednicaView> sedniceViews = new List<VanrednaSednicaView>();
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<VanrednaSednica> sednice = session.Query<VanrednaSednica>().ToList();

                foreach (var sednica in sednice)
                {
                    sedniceViews.Add(new VanrednaSednicaView(sednica));
                }

                session.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return sedniceViews;
        }

        public static VanrednaSednicaView ReadVanrednaSednica(int Id)
        {
            VanrednaSednicaView vanrednaSednica;
            try
            {
                ISession session = DataLayer.GetSession();

                VanrednaSednica sednica = session.Load<VanrednaSednica>(Id);

                vanrednaSednica = new VanrednaSednicaView(sednica);
                session.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return vanrednaSednica;
        }

        public static void CreateVanrednaSednica(VanrednaSednicaView vanrednaSednica)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                VanrednaSednica sednica = new VanrednaSednica();

                sednica.BrojSaziva = vanrednaSednica.BrojSaziva;
                sednica.BrojZasedanja = vanrednaSednica.BrojZasedanja;
                sednica.DatumPocetka = vanrednaSednica.DatumPocetka;
                sednica.DatumZavrsetka = vanrednaSednica.DatumZavrsetka;
                sednica.TipVanredneSednice = vanrednaSednica.TipVanredneSednice;

                session.Save(sednica);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void UpdateVanrednaSednica(VanrednaSednicaView vanrednaSednica)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                VanrednaSednica sednica = session.Load<VanrednaSednica>(vanrednaSednica.Id);

                sednica.BrojSaziva = vanrednaSednica.BrojSaziva;
                sednica.BrojZasedanja = vanrednaSednica.BrojZasedanja;
                sednica.DatumPocetka = vanrednaSednica.DatumPocetka;
                sednica.DatumZavrsetka = vanrednaSednica.DatumZavrsetka;

                session.Save(sednica);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DeleteVanrednaSednica(int Id)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                VanrednaSednica vanrednaSednica = session.Load<VanrednaSednica>(Id);

                session.Delete(vanrednaSednica);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<NarodniPoslanikView> ReadSazivaoci(int Id)
        {
            List<NarodniPoslanikView> sazivaociViews = new List<NarodniPoslanikView>();
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<NarodniPoslanik> sazivaoci = session.Query<NarodniPoslanik>()
                    .Where(p => p.JeSazvaoSednice.Any<JeSazvalo>(js => js.Sednica.Id == Id && js.Sednica.TipVanredneSednice == "na zahtev narodnih poslanika"))
                    .ToList();

                foreach(var poslanik in sazivaoci)
                {
                    sazivaociViews.Add(new NarodniPoslanikView(poslanik));
                }

                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return sazivaociViews;
        }

        #endregion

        #region RadniDan

        public static List<RadniDanView> ReadRadniDani(int sednicaId)
        {
            List<RadniDanView> radniDaniViews = new List<RadniDanView>();
            try
            {
                ISession session = DataLayer.GetSession();

                List<RadniDan> radniDani = session.Query<RadniDan>()
                                            .Where(r => r.Sednica.Id == sednicaId)
                                            .ToList();

                foreach(var radniDan in radniDani)
                {
                    radniDaniViews.Add(new RadniDanView(radniDan));
                }

                session.Close();

                return radniDaniViews;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static RadniDanView ReadRadniDan(int sednicaId, int Id)
        {
            RadniDanView radniDanView;
            try
            {
                ISession session = DataLayer.GetSession();

                RadniDan radniDan = session.Query<RadniDan>()
                                            .FirstOrDefault(r => r.Id == Id && r.Sednica.Id == sednicaId);

                radniDanView = new RadniDanView(radniDan);

                session.Close();

                return radniDanView;
            }
            catch (Exception)
            {
                throw;
            }
            return radniDanView;
        }

        public static bool CreateRadniDan(int sednicaId, RadniDanView radniDan)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                Sednica sednica = session.Load<Sednica>(sednicaId);

                // da li mozemo dodati radniDan

                int brojSacuvanihDana = session.Query<RadniDan>().Where(r => r.Sednica.Id == sednicaId).Count();

                int brojDanaKojeMozeDaIma = sednica.DatumZavrsetka.Subtract(sednica.DatumPocetka).Days + 1;

                if (brojSacuvanihDana < brojDanaKojeMozeDaIma)
                {
                    RadniDan dan = new RadniDan()
                    {
                        DatumIVremePocetka = radniDan.DatumIVremePocetka,
                        DatumIVremeZavrsetka = radniDan.DatumIVremeZavrsetka,
                        Sednica = sednica,
                        BrojPrisutnihPoslanika = radniDan.BrojPrisutnihPoslanika
                    };

                    session.Save(dan);
                    session.Flush();
                    session.Close();
                    return true;
                }

                session.Close();
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdateRadniDan(int sednicaId, RadniDanView radniDanView)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadniDan radniDan = session.Query<RadniDan>()
                                           .FirstOrDefault(r => r.Id == radniDanView.Id && r.Sednica.Id == sednicaId);

                radniDan.DatumIVremePocetka = radniDanView.DatumIVremePocetka;
                radniDan.DatumIVremeZavrsetka = radniDanView.DatumIVremeZavrsetka;
                radniDan.BrojPrisutnihPoslanika = radniDanView.BrojPrisutnihPoslanika;

                session.Save(radniDan);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DeleteRadniDan(int sednicaId, int Id)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadniDan radniDan = session.Query<RadniDan>()
                                           .FirstOrDefault(r => r.Id == Id && r.Sednica.Id == sednicaId);

                session.Delete(radniDan);
                session.Flush();
                session.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    
    }
}
