using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.ViewModels
{
    public class VozilaIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int voziloId { get; set; }
            public string naziv { get; set; }
            public string tipVozila { get; set; }
            public string godiste { get; set; }
            public bool iznajmljen { get; set; }
            public string cijena { get; set; }
        }
    }
}
