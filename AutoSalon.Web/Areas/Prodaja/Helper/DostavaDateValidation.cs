using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.Helper
{
    public class DostavaDateValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime uneseniDatum = (DateTime)value;

            if(uneseniDatum > DateTime.Now.AddDays(30).Date)
                return new ValidationResult("Neispravan unos. Datum dostave mora biti u roku 30 dana.");

            if (uneseniDatum < DateTime.Now.Date)
                return new ValidationResult("Neispravan unos.");

            return ValidationResult.Success;
        }
    }
}
