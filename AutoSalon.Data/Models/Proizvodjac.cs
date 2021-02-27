using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSalon.Data.Models
{
    public class Proizvodjac
    {
        public int ProizvodjacID { get; set; }
        public string Naziv { get; set; }

        public Grad Grad { get; set; }
        public int? GradID { get; set; }
    }
}
