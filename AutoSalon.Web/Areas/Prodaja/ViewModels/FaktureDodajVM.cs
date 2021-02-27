using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{

    public class FaktureDodajVM
    {
        public int NarudzbaId { get; set; }
        public DateTime DatumFakturisanja { get; set; }
        public string Datum { get; set; }

        [ValidateNever]
        public int? PopustId { get; set; }
        public List<SelectListItem> Popusti { get; set; }

        public int ZaposlenikId { get; set; }
    }
}
