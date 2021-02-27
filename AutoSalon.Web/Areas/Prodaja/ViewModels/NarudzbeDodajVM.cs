using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{

    public class NarudzbeDodajVM
    {
        public DateTime DatumNarudzbe { get; set; }
        public string Datum { get; set; }
        public List<SelectListItem> Klijenti { get; set; }
        public int? KlijentId { get; set; }   
    }
}
