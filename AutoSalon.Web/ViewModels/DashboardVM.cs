using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.ViewModels
{
    public class DashboardVM
    {
        public int BrojKlijenata { get; set; }
        public int BrojVozila { get; set; }
        public int BrojRentacar { get; set; }
        public int BrojIzvjestaja { get; set; }
        public int BrojOsiguranja { get; set; }
        public int BrojNarudzbi { get; set; }
        public int BrojFaktura { get; set; }
        public int BrojUplata { get; set; }
    }
}
