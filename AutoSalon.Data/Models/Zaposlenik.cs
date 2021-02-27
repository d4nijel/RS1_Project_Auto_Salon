using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Data.Models
{
    public class Zaposlenik
    {
        public int ZaposlenikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Spol { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int Staz { get; set; }
        public string TipUgovora { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsMenadzer { get; set; }
        public bool IsProdavac { get; set; }
        public bool IsRent { get; set; }

        public Grad Prebivaliste { get; set; }
        public int? PrebivalisteID { get; set; }

    }
}
