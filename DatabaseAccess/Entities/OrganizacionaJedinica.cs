using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public abstract class OrganizacionaJedinica
    {
        public virtual int Id { get; protected set; }
        public virtual string Tip { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string TipRadnogTela { get; set; }

        public virtual NarodniPoslanik Predsednik { get; set; }
        public virtual NarodniPoslanik Zamenik { get; set; }

        public virtual IList<JeClan> JeClanNarodniPoslanici { get; set; }

        public virtual IList<JeDodeljena> JeDodeljenaSluzbeneProstorije { get; set; }

        public OrganizacionaJedinica()
        {
            JeClanNarodniPoslanici = new List<JeClan>();

            JeDodeljenaSluzbeneProstorije = new List<JeDodeljena>();
        }
    }

    public class PoslanickaGrupa : OrganizacionaJedinica
    {
    }

    public class RadnoTelo : OrganizacionaJedinica
    {
    }
}
