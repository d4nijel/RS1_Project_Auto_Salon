
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Data.Models
{
    public class StavkaNarudzbe
    {
        public int Kolicina { get; set; }
        public double CijenaPoKomadu { get; set; }

        public Vozilo Vozilo { get; set; }
        public int? VoziloID { get; set; }

        public Narudzba Narudzba { get; set; }
        public int? NarudzbaID { get; set; }
    }
}
