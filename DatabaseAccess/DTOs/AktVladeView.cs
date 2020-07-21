using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class AktVladeView : AktView
    {
        public AktVladeView() : base()
        { }

        public AktVladeView(AktVlade aktVlade) : base(aktVlade)
        { }
    }
}
