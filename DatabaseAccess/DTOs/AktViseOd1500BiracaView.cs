using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class AktViseOd1500BiracaView : AktView
    {
        public int BrojBiraca { get; set; }

        public AktViseOd1500BiracaView() : base()
        {

        }

        public AktViseOd1500BiracaView(AktViseOd1500Biraca aktViseOd1500Biraca) : base(aktViseOd1500Biraca)
        {
            this.BrojBiraca = aktViseOd1500Biraca.BrojBiraca;
        }
    }
}
