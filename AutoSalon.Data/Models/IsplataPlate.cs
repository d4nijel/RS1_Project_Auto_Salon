using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AutoSalon.Data.Models
{
    public class IsplataPlate
    {
        public int IsplataPlateId { get; set; }
        public int Iznos { get; set; }
        public int Bonus { get; set; }
        public string Napomena { get; set; }

        public Zaposlenik Zaposlenik { get; set; }
        public int? ZaposlenikId { get; set; }

        public Period Period { get; set; }
        public int? PeriodID { get; set; }
    }
}
