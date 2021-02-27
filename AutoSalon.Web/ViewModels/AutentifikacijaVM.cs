using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.ViewModels
{
    public class AutentifikacijaVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImePrezime { get; set; }
        public int ZaposlenikId { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsMenadzer { get; set; }
        public bool IsProdavac { get; set; }
        public bool IsRent { get; set; }
    }
}
