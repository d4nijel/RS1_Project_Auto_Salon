using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AutoSalon.Data.Models
{
    public class Faktura
    {
        public int FakturaID { get; set; }
        public DateTime Datum { get; set; }

        public StatusFakture StatusFakture { get; set; }
        public int? StatusFaktureID { get; set; }

        public Zaposlenik Zaposlenik { get; set; }
        public int? ZaposlenikID { get; set; }

        public Popust Popust { get; set; }
        public int? PopustID { get; set; }

        public Dostava Dostava { get; set; }
        public int? DostavaID { get; set; }


    }
}
