using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Data.Models
{
    public class PolicaOsiguranja
    {
        public int PolicaOsiguranjaID { get; set; }
        public int BrojPolice { get; set; }
        public DateTime PocetakUgovora { get; set; }
        public DateTime KrajUgovora { get; set; }
 
        public OsiguravajucaFirma OsiguravajucaFirma { get; set; }
        public int? OsiguravajucaFirmaID { get; set; }

        public Vozilo Vozilo { get; set; }
        public int? VoziloID { get; set; }
    }
}
