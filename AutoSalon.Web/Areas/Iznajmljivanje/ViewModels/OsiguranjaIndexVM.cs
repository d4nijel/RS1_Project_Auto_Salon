using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class OsiguranjaIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int policaId { get; set; }
            public string brojPolice { get; set; }
            public string osiguravajucaFirma { get; set; }
            public string vozilo { get; set; }
            public string krajUgovora { get; set; }
        }
    }
}
