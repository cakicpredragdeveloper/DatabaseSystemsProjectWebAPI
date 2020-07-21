using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class VanrednaSednicaView : SednicaView
    {
        public string TipVanredneSednice { get; set; }

        public VanrednaSednicaView() : base()
        { }

        public VanrednaSednicaView(VanrednaSednica vanrednaSednica) : base(vanrednaSednica)
        {
            this.TipVanredneSednice = vanrednaSednica.TipVanredneSednice;
        }
    }
}
