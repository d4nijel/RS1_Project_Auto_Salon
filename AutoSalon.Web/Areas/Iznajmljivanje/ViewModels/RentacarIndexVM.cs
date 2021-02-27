using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class RentacarIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {

            public int rentId { get; set; }
            public string vozilo { get; set; }
            public string klijent { get; set; }
            public string zaposlenik { get; set; }
            public DateTime datumRentanja { get; set; }
            public DateTime datumIsteka { get; set; }
            public string cijena { get; set; }
            public bool isZavrseno { get; set; }
        }
    }
}
