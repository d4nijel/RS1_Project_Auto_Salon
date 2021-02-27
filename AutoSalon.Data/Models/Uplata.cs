
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Data.Models
{
    public class Uplata
    {
        public int UplataID { get; set; }
        public double Iznos { get; set; }
        public DateTime Datum { get; set; }

        public NacinPlacanja NacinPlacanja { get; set; }
        public int? NacinPlacanjaID { get; set; }

        public Klijent Klijent { get; set; }
        public int? KlijentID { get; set; }

        public Faktura Faktura { get; set; }
        public int? FakturaID { get; set; }

    }
}
