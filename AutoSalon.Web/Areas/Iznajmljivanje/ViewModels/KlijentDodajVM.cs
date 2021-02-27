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
    public class KlijentDodajVM
    {

        public int KlijentID { get; set; }
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "JMBG je obavezan")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Unos nije ispravan")]
        public string JMBG { get; set; }
        [KlijentDateValidation]
        public DateTime DatumRodjenja { get; set; }
        [RegularExpression("([0-9]{3})/([0-9]{3})-([0-9]{3})", ErrorMessage = "Unos nije ispravan, pattern mora biti xxx/xxx-xxx")]
        public string Telefon { get; set; }
        [EmailAddress(ErrorMessage = "Unesite ispravan e-mail")]
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string PostanskiBroj { get; set; }
        public string Spol { get; set; }
        [ValidateNever]
        public int? GradID { get; set; }
        public List<SelectListItem> gradovi { get; set; }
    }
}
