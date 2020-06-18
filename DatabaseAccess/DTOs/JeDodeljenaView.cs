using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class JeDodeljenaView
    {
        public virtual int Id { get; protected set; }
        public virtual OrganizacionaJedinicaView OrganizacionaJedinica { get; set; }
        // public virtual SluzbenaProstorijaView SluzbenaProstorija { get; set; }

        public JeDodeljenaView()
        {
        }

        public JeDodeljenaView(JeDodeljena jeDodeljena)
        {
            Id = jeDodeljena.Id;
            OrganizacionaJedinica = new OrganizacionaJedinicaView(jeDodeljena.OrganizacionaJedinica);
            // SluzbenaProstorija = new SluzbenaProstorijaView(jeDodeljena.SluzbenaProstorija);
        }
    }
}
