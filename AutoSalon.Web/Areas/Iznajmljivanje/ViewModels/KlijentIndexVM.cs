using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class KlijentIndexVM
    {
        
        public List<Row> rows { get; set; }

        public class Row
        {
            public string imePrezime { get; set; }
            public string adresa { get; set; }
            public string telefon { get; set; }
            public int klijentId { get; set; }
        }
    }
}
