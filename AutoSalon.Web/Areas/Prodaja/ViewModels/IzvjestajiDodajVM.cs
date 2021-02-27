using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class IzvjestajiDodajVM
    {
        public int IzvjestajId { get; set; }
        public int? ZaposlenikId { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string Datum { get; set; }

        [StringLength(255, ErrorMessage = "Neispravan unos. Prekoračili ste maksimalan broj dozvoljenih karaktera.")]
        public string Napomena { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [StringLength(50, ErrorMessage = "Neispravan unos. Prekoračili ste maksimalan broj dozvoljenih karaktera.")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [StringLength(255, ErrorMessage = "Neispravan unos. Prekoračili ste maksimalan broj dozvoljenih karaktera.")]
        public string Sadrzaj { get; set; }
    }
}
