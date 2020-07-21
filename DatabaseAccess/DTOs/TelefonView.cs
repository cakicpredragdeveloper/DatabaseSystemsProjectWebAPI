using System.Collections.Generic;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class TelefonView
    {
        public virtual int Id { get; protected set; }
        public virtual string BrojTelefona { get; set; }

        public virtual NarodniPoslanikView NarodniPoslanik { get; set; }

        public TelefonView()
        {
        }

        public TelefonView(Telefon telefon)
        {
            Id = telefon.Id;
            BrojTelefona = telefon.BrojTelefona;
        }

        public TelefonView(Telefon telefon, NarodniPoslanik narodniPoslanik)
        {
            Id = telefon.Id;
            BrojTelefona = telefon.BrojTelefona;
            NarodniPoslanik = new NarodniPoslanikView(narodniPoslanik);
        }
    }
}
