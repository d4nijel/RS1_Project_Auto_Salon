using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSalon.Data.Models
{
    public class Motor
    {
        public int MotorID { get; set; }
        public string VrstaMotora { get; set; }
        public string  Model { get; set; }
        public int ZapreminaMotora { get; set; }
        public int BrojCilindara { get; set; }
        public int Snaga { get; set; }
        public string Potrosnja { get; set; }
    }
}
