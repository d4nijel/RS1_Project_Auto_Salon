using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class KlijentiIndexVM
    {
        public class Red
        {
            public int KlijentId { get; set; }
            public string ImePrezime { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public string Adresa { get; set; }
            public string Grad { get; set; }
        }
        public List<Red> Redovi { get; set; }
    }
}
