using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class NarudzbeDetaljiVM
    {
        public int BrojNarudzbe { get; set; }
        public string DatumNarudzbe { get; set; }
        public string Status { get; set; }
        public string KlijentImePrezime { get; set; }
        public int StatusNarudzbeId { get; set; }
        public bool Provjera { get; set; }
    }
}
