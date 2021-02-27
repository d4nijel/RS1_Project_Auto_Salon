using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class FaktureDetaljiVM
    {
        public int FakturaId { get; set; }
        public DateTime DatumFakture { get; set; }
        public string Datum { get; set; }
        public string Status { get; set; }

        [ValidateNever]
        public int? PopustId { get; set; }
        public List<SelectListItem> Popusti { get; set; }

        public string Popust { get; set; }
        public string ZaposlenikImePrezime { get; set; }
        public double UkupnaCijena { get; set; }
        public double UkupnaCijenaSaPDV { get; set; }
        public int? DostavaId { get; set; }
        public int? StatusFaktureId { get; set; }

        public int? NarudzbaId { get; set; }
        public string KlijentImePrezime { get; set; }
    }
}
