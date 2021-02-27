using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class VozilaIndexVM
    {
        public class Red
        {
            public int VoziloId { get; set; }
            public string Proizvodjac { get; set; }
            public string Model { get; set; }
            public int GodinaProizvodnje { get; set; }
            public double Cijena { get; set; }
            public string Motor { get; set; }
        }
        public List<Red> Redovi { get; set; }
    }
}
