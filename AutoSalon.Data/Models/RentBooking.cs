
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Data.Models
{
    public class RentBooking
    {
        public int RentBookingID { get; set; }
        public DateTime DatumRentanja { get; set; }
        public DateTime DatumIsteka { get; set; }
        public double CijenaPoSatu { get; set; }
        public bool isZavrseno { get; set; }

        public double UkupnaCijena
        {
            get{
                return DatumIsteka.Subtract(DatumRentanja).TotalHours * CijenaPoSatu;
            }
        }

        public Vozilo Vozilo { get; set; }
        public int? VoziloID { get; set; }

        public Zaposlenik Zaposlenik { get; set; }
        public int? ZaposlenikID { get; set; }

        public Faktura Faktura { get; set; }
        public int? FakturaID { get; set; }

        public Klijent Klijent { get; set; }
        public int? KlijentID { get; set; }
    }
}
