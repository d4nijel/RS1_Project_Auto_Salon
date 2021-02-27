using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class DostaveIndexVM
    {
        public int DostavaId { get; set; }
        public string DostavljackaFirma { get; set; }
        public DateTime DatumDostave { get; set; }
        public bool BrzaDostava { get; set; }
        public double Cijena { get; set; }
        public DateTime KrajnjiDatumDostave { get; set; }
        public int FakturaId { get; set; }
        public int? StatusFaktureId { get; set; }
    }
}
