using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Data.Models
{
    public class Popust
    {
        public int PopustID { get; set; }
        public string Naziv { get; set; }
        public double Procenat { get; set; }
        public string Opis { get; set; }


    }
}
