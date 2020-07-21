using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class PoslanickaGrupaPost
    {
        public virtual string Naziv { get; set; }
        public virtual int PredsednikId { get; set; }
        public virtual int ZamenikId { get; set; }

        public PoslanickaGrupaPost()
        {
        }
    }
}
