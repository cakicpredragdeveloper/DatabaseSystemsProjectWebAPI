using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class JePredlozio
    {
        public virtual int Id { get; protected set; }
        public virtual NarodniPoslanik NarodniPoslanik { get; set; }
        public virtual AktNarodnihPoslanika Akt { get; set; }
    }
}
