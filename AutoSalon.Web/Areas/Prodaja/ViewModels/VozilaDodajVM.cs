using AutoSalon.Web.Areas.Prodaja.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{

    public class VozilaDodajVM
    {
        public int VoziloId { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [StringLength(15, ErrorMessage = "Neispravan unos. Prekoračili ste maksimalan broj dozvoljenih karaktera.")]
        public string Boja { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [Range(1,5, ErrorMessage = "Neispravan unos. Možete unijeti od 1 do 5.")]
        public int BrojVrata { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [Range(1, 1000000, ErrorMessage = "Neispravan unos.")]
        public double Cijena { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [Range(1, 10, ErrorMessage = "Neispravan unos. Možete unijeti od 1 do 10.")]
        public int Garancija { get; set; }
     
        [Required(ErrorMessage = "Unos je obavezan")]
        [RangeUntilCurrentYear(1900, ErrorMessage = "Neispravan unos. Unesite ispravnu godinu.")]
        public int GodinaProizvodnje { get; set; }

        public string Mjenjac { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [StringLength(50, ErrorMessage = "Neispravan unos. Prekoračili ste maksimalan broj dozvoljenih karaktera.")]
        public string Model { get; set; }

        public List<SelectListItem> Motori { get; set; }
        public int? MotorId { get; set; }

        public string Oprema { get; set; }

        public string Pogon { get; set; }

        public List<SelectListItem> Proizvodjaci { get; set; }
        public int? ProizvodjacId { get; set; }

        public string TipVozila { get; set; }

        public string Proizvodjac { get; set; }
        public string Motor { get; set; }
    }
}
