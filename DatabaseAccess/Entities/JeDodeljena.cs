using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class JeDodeljena
    {
        public virtual int Id { get; protected set; }
        public virtual OrganizacionaJedinica OrganizacionaJedinica { get; set; }
        public virtual SluzbenaProstorija SluzbenaProstorija { get; set; }
    }
}
