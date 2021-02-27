using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSalon.Data.Models
{
    public class Grad
    {
        public int GradID { get; set; }
        public string Naziv { get; set; }
        public Drzava Drzava { get; set; }
        public int? DrzavaID { get; set; }
    }
}
