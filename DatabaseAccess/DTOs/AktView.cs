using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class AktView
    {
        public int Id { get; set; }
        public string TipAkta { get; set; }

        public AktView()
        { }

        public AktView(Akt akt)
        {
            this.Id = akt.Id;
            this.TipAkta = akt.TipAkta;
        }
    }
}
