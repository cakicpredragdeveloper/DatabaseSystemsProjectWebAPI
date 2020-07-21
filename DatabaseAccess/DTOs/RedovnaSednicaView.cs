using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class RedovnaSednicaView : SednicaView
    {
        public RedovnaSednicaView() : base()
        { }

        public RedovnaSednicaView(RedovnaSednica redovnaSednica) : base(redovnaSednica)
        { }
    }
}
