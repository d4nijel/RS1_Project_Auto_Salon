using AutoSalon.Data.Models;
using AutoSalon.Web.Areas.Iznajmljivanje.Helper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class RentacarDodajVM
    {
        public int RentBookingID { get; set; }
        public DateTime DatumRentanja { get; set; }
        [RentacarDateValidation]
        public DateTime DatumIsteka { get; set; }
        [Required(ErrorMessage = "Odabir vozila je obavezan")]
        public int? VoziloID { get; set; }
        public List<SelectListItem> vozila { get; set; }
        [ValidateNever]
        public int? ZaposlenikID { get; set; }
        public List<SelectListItem> zaposlenici { get; set; }
        [Required(ErrorMessage = "Odabir klijenta je obavezan")]
        public int? KlijentID { get; set; }
        public List<SelectListItem> klijenti { get; set; }
        [ValidateNever]
        public int? PopustID { get; set; }
        public List<SelectListItem> popusti { get; set; }
    }
}
