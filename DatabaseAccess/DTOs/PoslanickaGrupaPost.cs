using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class PoslanickaGrupaView: OrganizacionaJedinicaView
    {
        public virtual string Naziv { get; set; }

        public PoslanickaGrupaView(): base()
        {
        }

        public PoslanickaGrupaView(PoslanickaGrupa poslanickaGrupa) : base(poslanickaGrupa)
        {
            Naziv = poslanickaGrupa.Naziv;
        }

        public PoslanickaGrupaView(PoslanickaGrupa poslanickaGrupa, NarodniPoslanik predsednik, NarodniPoslanik zamenik) 
            : base(poslanickaGrupa, predsednik, zamenik)
        {
            Naziv = poslanickaGrupa.Naziv;
        }
    }
}
