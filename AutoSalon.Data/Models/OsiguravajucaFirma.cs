using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSalon.Data.Models
{
    public class OsiguravajucaFirma
    {
        public int OsiguravajucaFirmaID { get; set; }
        public string Naziv { get; set; }
        public string PDVBroj { get; set; }
        public string IDBroj { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string PostanskiBroj { get; set; }

        public Grad Grad { get; set; }
        public int? GradID { get; set; }
    }
}
