using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class PoslanickaGrupaView: OrganizacionaJedinicaView
    {
        public PoslanickaGrupaView(): base()
        {
        }

        public PoslanickaGrupaView(OrganizacionaJedinica organizacionaJedinica) : base(organizacionaJedinica)
        {
        }
    }
}
