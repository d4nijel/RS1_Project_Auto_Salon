using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSalon.Data.Models
{
    public class Vozilo
    {
        public int VoziloID { get; set; }
        public string TipVozila { get; set; }
        public string Model { set; get; }
        public string Mjenjac { get; set; }
        public string  Pogon { get; set; }
        public string Oprema { get; set; }
        public int Godinaproizvodnje { get; set; }
        public string Boja { get; set; }
        public int BrojVrata { get; set; }
        public int Garancija { get; set; }
        public double Cijena { get; set; }
        public bool isIznajmljeno { get; set; }

        public Motor Motor { get; set; }
        public int? MotorID { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        public int? ProizvodjacID { get; set; }
    }
}
