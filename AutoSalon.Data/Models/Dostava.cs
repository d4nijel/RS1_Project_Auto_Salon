using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AutoSalon.Data.Models
{
    public class Dostava
    {
        public int DostavaID { get; set; }
        public bool BrzaDostava { get; set; }
        public DateTime KrajnjiRok { get; set; }
        public DateTime Datum { get; set; }
        public double Cijena { get; set; }

        public DostavljackaFirma DostavljackaFirma { get; set; }
        public int? DostavljackaFirmaID { get; set; }
    }
}
