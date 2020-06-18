using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class RadnoTeloView: OrganizacionaJedinicaView
    {
        public RadnoTeloView(): base()
        {
        }

        public RadnoTeloView(OrganizacionaJedinica organizacionaJedinica) : base(organizacionaJedinica)
        {
        }
    }
}
