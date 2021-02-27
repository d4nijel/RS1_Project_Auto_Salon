using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class NarudzbeStavkeIndexVM
    {
        public class Red
        {
            public int? VoziloId { get; set; }
            public string ModelVozila { get; set; }
            public double Cijena { get; set; }
            public double Kolicina { get; set; }
            public double UkupnaCijena { get; set; }
            public double UkupnaCijenaSaPDV { get; set; }
        }
        public int NarudzbaId { get; set; }
        public int StatusNarudzbeId { get; set; }
        public List<Red> Redovi { get; set; }
    }
}
