using AutoSalon.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class IzvjestajiDodajVM
    {

        public int IzvjestajID { get; set; }
        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Sadržaj je obavezan")]
        public string Sadrzaj { get; set; }
        public string Napomena { get; set; }
        [ValidateNever]
        public Zaposlenik Zaposlenik { get; set; }
        public int? ZaposlenikId { get; set; }

    }
}
