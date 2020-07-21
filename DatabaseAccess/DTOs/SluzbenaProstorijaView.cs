using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class SluzbenaProstorijaView
    {
        public int Id { get; set; }
        public int Sprat { get; set; }
        public int Broj { get; set; }

        public SluzbenaProstorijaView()
        {
            
        }

        public SluzbenaProstorijaView(SluzbenaProstorija sluzbenaProstorija)
        {
            this.Id = sluzbenaProstorija.Id;
            this.Sprat = sluzbenaProstorija.Sprat;
            this.Broj = sluzbenaProstorija.Broj;
        }
    }
}