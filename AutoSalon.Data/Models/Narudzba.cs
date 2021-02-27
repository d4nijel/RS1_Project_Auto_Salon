
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AutoSalon.Data.Models
{
    public class Narudzba
    {
        public int NarudzbaID { get; set; }
        public DateTime Datum { get; set; }
        public double Cijena { get; set; }
        public Klijent Klijent { get; set; }
        public int? KlijentID { get; set; }

        public Faktura Faktura { get; set; }
        public int? FakturaID { get; set; }

        public StatusNarudzbe StatusNarudzbe { get; set; }
        public int StatusNarudzbeID { get; set; }
    }
}
