using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSalon.Data.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public double Ocjena { get; set; }
        public string Komentar { get; set; }
        public DateTime Datum { get; set; }

        public Vozilo Vozilo { get; set; }
        public int? VoziloID { get; set; }
        public Klijent Klijent { get; set; }
        public int? KlijentID { get; set; }
    }
}
