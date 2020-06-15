using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class JeSazvalo
    {
        public virtual int Id { get; protected set; }
        public virtual NarodniPoslanik NarodniPoslanik { get; set; }
        public virtual VanrednaSednica Sednica { get; set; }
    }
}
