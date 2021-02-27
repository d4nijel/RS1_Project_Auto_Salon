using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class IzvjestajiIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int IzvjestajID { get; set; }
            public string Naziv { get; set; }
            public string Datum { get; set; }
            public string Napomena { get; set; }
        }
    }
}
