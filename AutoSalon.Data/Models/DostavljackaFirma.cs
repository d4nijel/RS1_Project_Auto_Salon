using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AutoSalon.Data.Models
{
    public class DostavljackaFirma
    {
        public int DostavljackaFirmaID { get; set; }
        public string IDBroj { get; set; }
        public string PDVBroj { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Faks { get; set; }
        public string PostanskiBroj { get; set; }
        public Grad Grad { get; set; }
        public int? GradID { get; set; }
    }
}
