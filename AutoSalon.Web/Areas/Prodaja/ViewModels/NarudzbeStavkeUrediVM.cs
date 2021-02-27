using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class NarudzbeStavkeUrediVM
    {
        public int? NarudzbaId { get; set; }
        public int? VoziloId { get; set; }
        public string Vozilo { get; set; }
        public double Cijena { get; set; }

        [Required(ErrorMessage = "Unos je obavezan")]
        [Range(1, 100, ErrorMessage = "Neispravan unos.")]
        public int Kolicina { get; set; }
    }
}
