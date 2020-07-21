using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class OrganizacionaJedinicaView
    {
        public virtual int Id { get; protected set; }
        public virtual NarodniPoslanikView Predsednik { get; set; }
        public virtual NarodniPoslanikView Zamenik { get; set; }

        public OrganizacionaJedinicaView()
        {
        }

        public OrganizacionaJedinicaView(OrganizacionaJedinica organizacionaJedinica)
        {
            Id = organizacionaJedinica.Id;
        }

        public OrganizacionaJedinicaView(OrganizacionaJedinica organizacionaJedinica, NarodniPoslanik predsednik, NarodniPoslanik zamenik)
        {
            Id = organizacionaJedinica.Id;
    
            Predsednik = new NarodniPoslanikView(predsednik);
            Zamenik = new NarodniPoslanikView(zamenik);
        }
    }
}
