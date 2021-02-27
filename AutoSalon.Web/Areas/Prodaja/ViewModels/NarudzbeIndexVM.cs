using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class NarudzbeIndexVM
    {
        public class Red
        {
            public int BrojNarudzbe { get; set; }
            public DateTime DatumNarudzbe { get; set; }
            public string StatusNarudzbe { get; set; }
            public int StatusNarudzbeId { get; set; }
            public string KlijentImePrezime { get; set; }
            public double Cijena { get; set; }
            public double CijenaSaPDV { get; set; }
            public int? FakturaId { get; set; }
            public string StatusFakture { get; set; }
        }
        public List<Red> Redovi { get; set; }
    }
}
