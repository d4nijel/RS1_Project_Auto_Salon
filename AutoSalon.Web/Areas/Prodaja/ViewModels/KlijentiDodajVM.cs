using AutoSalon.Web.Areas.Prodaja.Helper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class KlijentiDodajVM
    {
        public int KlijentId { get; set; }

        [Required(ErrorMessage ="Unos je obavezan")]
        [StringLength(50,ErrorMessage = "Neispravan unos. Prekoračili ste maksimalan broj dozvoljenih karaktera.")]
        public string Adresa { get; set; }

        [KlijentDateValidation]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [RegularExpression(@"[a-z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Unos nije ispravan")]
        public string Email { get; set; }

        public int? GradId { get; set; }
        public List<SelectListItem> Gradovi { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [StringLength(30, ErrorMessage = "Neispravan unos. Prekoračili ste maksimalan broj dozvoljenih karaktera.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [RegularExpression("[0-9]{13}", ErrorMessage = "Unos nije ispravan. JMBG sadrži 13 cifara.")]
        public string JMBG { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [StringLength(20, ErrorMessage = "Neispravan unos. Prekoračili ste maksimalan broj dozvoljenih karaktera.")]
        public string PostanskiBroj { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [StringLength(30, ErrorMessage = "Neispravan unos. Prekoračili ste maksimalan broj dozvoljenih karaktera.")]
        public string Prezime { get; set; }

        public string Spol { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [RegularExpression("([0-9]{3})/([0-9]{3})-([0-9]{3})", ErrorMessage = "Unos nije ispravan. Ispravan format za unos broja telefona je: xxx/xxx-xxx")]
        public string Telefon { get; set; }
    }
}
