using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class FaktureIndexVM
    {
        public class Red
        {
            public int FakturaId { get; set; }
            public DateTime DatumFakture { get; set; }
            public string Popust { get; set; }
            public string Status { get; set; }
            public int? StatusFaktureId { get; set; }
            public string ZaposlenikImePrezime { get; set; }
            public double UkupnaCijena { get; set; }
            public double UkupnaCijenaSaPDV { get; set; }

            public int? NarudzbaId { get; set; }
            public string KlijentImePrezime { get; set; }
        }
        public List<Red> Redovi { get; set; }
    }
}
