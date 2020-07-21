using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class StalnoZaposlenView : NarodniPoslanikView
    {
        public virtual int Brk { get; set; }
        public virtual int RsGodine { get; set; }
        public virtual int RsMeseci { get; set; }
        public virtual int RsDani { get; set; }
        public virtual string ImeFirme { get; set; }

        public StalnoZaposlenView(): base()
        {

        }

        public StalnoZaposlenView(StalnoZaposlen stalnoZaposlen): base(stalnoZaposlen)
        {
            Brk = stalnoZaposlen.Brk;
            RsGodine = stalnoZaposlen.RsGodine;
            RsMeseci = stalnoZaposlen.RsMeseci;
            RsDani = stalnoZaposlen.RsDani;
            ImeFirme = stalnoZaposlen.ImeFirme;
        }

        public StalnoZaposlenView(
            StalnoZaposlen stalnoZaposlen,
            IList<OrganizacionaJedinica> jePredsednik,
            IList<OrganizacionaJedinica> jeZamenik,
            IList<Telefon> telefoni): base(stalnoZaposlen, jePredsednik, jeZamenik, telefoni)
        {
            Brk = stalnoZaposlen.Brk;
            RsGodine = stalnoZaposlen.RsGodine;
            RsMeseci = stalnoZaposlen.RsMeseci;
            RsDani = stalnoZaposlen.RsDani;
            ImeFirme = stalnoZaposlen.ImeFirme;
        }
    }
}
