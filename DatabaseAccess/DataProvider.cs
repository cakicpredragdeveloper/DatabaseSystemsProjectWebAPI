using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DatabaseAccess.DTOs;
using NHibernate;
using DatabaseAccess.Entities;
using DatabaseAccess.Mappings;
using NHibernate.Mapping.ByCode.Impl;

namespace DatabaseAccess
{
    public class DataProvider
    {
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
            catch(Exception ex)
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

                foreach(var predlagac in predlagaci)
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

                foreach(var prostorija in prostorije)
                {
                    sluzbeneProstorije.Add(new SluzbenaProstorijaView(prostorija));
                }
                
                session.Close();
            }
            catch(Exception)
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
            catch(Exception)
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
            catch(Exception)
            {
                throw;
            }
        }

        //public static List<Organizacionajedinicaview> ReadOrgaznizacioneJedinice(int Id)
        //{

        //}

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
    }
}
