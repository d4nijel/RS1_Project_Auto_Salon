using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class UplateIndexVM
    {
        public class Red
        {
            public int? FakturaId { get; set; }
            public DateTime DatumUplate { get; set; }
            public double Iznos { get; set; }
            public string KlijentImePrezime { get; set; }
            public string NacinPlacanja { get; set; }
        }
        public List<Red> Redovi { get; set; }
    }
}
