using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSalon.Data.Models
{
    public class Klijent
    {
        public int KlijentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string PostanskiBroj { get; set; }
        public string Spol { get; set; }

        public Grad Grad { get; set; }
        public int? GradID { get; set; }
    }
}
