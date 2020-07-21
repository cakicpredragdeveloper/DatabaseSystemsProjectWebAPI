using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class JeClanView
    {
        public virtual int Id { get; protected set; }
        public virtual NarodniPoslanikView NarodniPoslanik { get; set; }
        public virtual OrganizacionaJedinicaView OrganizacionaJedinica { get; set; }

        public JeClanView()
        {
        }  

        public JeClanView(JeClan jeClan)
        {
            Id = jeClan.Id;
            NarodniPoslanik = new NarodniPoslanikView(jeClan.NarodniPoslanik);
            OrganizacionaJedinica = new OrganizacionaJedinicaView(jeClan.OrganizacionaJedinica);
        }
    }
}
