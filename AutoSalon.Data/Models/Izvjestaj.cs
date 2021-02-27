using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AutoSalon.Data.Models
{
    public class Izvjestaj
    {
        public int IzvjestajID { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public string Sadrzaj { get; set; }
        public string Napomena { get; set; }

        public Zaposlenik Zaposlenik { get; set; }
        public int? ZaposlenikId { get; set; }
    }
}
