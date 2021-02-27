using AutoSalon.Web.Areas.Iznajmljivanje.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class OsiguranjaDodajVM
    {
        public int PolicaOsiguranjaID { get; set; }
        [Required(ErrorMessage = "Unos broja police je obavezan")]
        [Range(1, 9999999, ErrorMessage = "Broj police ne može biti 0")]
        public int BrojPolice { get; set; }
        public DateTime PocetakUgovora { get; set; }
        [OsiguranjaDateValidation]
        public DateTime KrajUgovora { get; set; }

        [Required(ErrorMessage = "Odabir vozila je obavezan")]
        public int? OsiguravajucaFirmaID { get; set; }
        public List<SelectListItem> osiguravajuceFirme { get; set; }

        [Required(ErrorMessage = "Odabir vozila je obavezan")]
        public int? VoziloID { get; set; }
        public List<SelectListItem> vozila { get; set; }
        
    }
}
