using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class UplateDodajVM
    {
        public int UplataId { get; set; }
        public int? FakturaId { get; set; }
        public DateTime DatumUplate { get; set; }
        public string Datum { get; set; }
        public double Iznos { get; set; }
        public string IznosSaPDV { get; set; }
        public string KlijentImePrezime { get; set; }
        public int? KlijentId { get; set; }
        public List<SelectListItem> NaciniPlacanja { get; set; }
        public int? NacinPlacanjaId { get; set; }
    }
}
