using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class RadnoTeloPost
    {
        public virtual string TipRadnogTela { get; set; }

        public virtual int PredsednikId { get; set; }
        public virtual int ZamenikId { get; set; }

        public RadnoTeloPost()
        {
        }
    }
}
