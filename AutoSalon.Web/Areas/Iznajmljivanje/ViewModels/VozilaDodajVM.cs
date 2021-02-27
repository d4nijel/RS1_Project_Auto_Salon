using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class VozilaDodajVM
    {
        public int VoziloID { get; set; }
        public string TipVozila { get; set; }
        [Required(ErrorMessage = "Unos modela je obavezan")]
        public string Model { set; get; }
        public string Mjenjac { get; set; }
        public string Pogon { get; set; }
        public string Oprema { get; set; }
        [Required(ErrorMessage = "Unos godine proizvodnje je obavezan")]
        [RegularExpression("[0-9]{4}", ErrorMessage = "Format nije ispravan")]
        public int Godinaproizvodnje { get; set; }
        public string Boja { get; set; }
        public int BrojVrata { get; set; }
        public int Garancija { get; set; }
        [Required(ErrorMessage = "Unos cijene je obavezan")]
        [Range(1,9999999, ErrorMessage = "Cijena ne može biti 0")]
        public double Cijena { get; set; }

        [ValidateNever]
        public int? MotorID { get; set; }
        public List<SelectListItem> motori { get; set; }

        [Required(ErrorMessage = "Odaberite proizvođača")]
        public int? ProizvodjacID { get; set; }
        public List<SelectListItem> proizvodjaci { get; set; }
        
    }
}
