using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.ViewModels
{
    public class IzvjestajiIndexVM
    {
        public class Red
        {
            public int IzvjestajId { get; set; }
            public DateTime DatumKreiranja { get; set; }
            public string Napomena { get; set; }
            public string Naziv { get; set; }
        }
        public List<Red> Redovi { get; set; }
    }
}
