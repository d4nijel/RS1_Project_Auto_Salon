using AutoSalon.Web.Areas.Iznajmljivanje.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class RentacarUrediVM
    {
        public int RentBookingID { get; set; }
        [RentacarDateValidation]
        public DateTime DatumIsteka { get; set; }
        public string vozilo { get; set; }
        public string klijent { get; set; }
        public string popust { get; set; }
        public bool isZavrsen { get; set; }
    }
}
