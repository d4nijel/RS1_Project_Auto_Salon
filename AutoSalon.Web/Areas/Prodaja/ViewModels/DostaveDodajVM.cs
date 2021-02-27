using AutoSalon.Web.Areas.Prodaja.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class DostaveDodajVM
    {
        public List<SelectListItem> DostavljackeFirme { get; set; }
        public int? DostavljackaFirmaId { get; set; }

        [DostavaDateValidation]
        public DateTime DatumDostave { get; set; }
        public bool BrzaDostava { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [Range(1, 1000000, ErrorMessage = "Neispravan unos.")]
        public double Cijena { get; set; }

        [DostavaKDateValidation]
        public DateTime KrajnjiDatumDostave { get; set; }

        public int FakturaId { get; set; }
        public int DostavaId { get; set; }
    }
}
