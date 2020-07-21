using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class RadnoTeloView: OrganizacionaJedinicaView
    {
        public virtual string TipRadnogTela { get; set; }

        public RadnoTeloView(): base()
        {
        }

        public RadnoTeloView(RadnoTelo radnoTelo) : base(radnoTelo)
        {
            TipRadnogTela = radnoTelo.TipRadnogTela;
        }

        public RadnoTeloView(RadnoTelo radnoTelo, NarodniPoslanik predsednik, NarodniPoslanik zamenik)
            : base(radnoTelo, predsednik, zamenik)
        {
            TipRadnogTela = radnoTelo.TipRadnogTela;
        }
    }
}
