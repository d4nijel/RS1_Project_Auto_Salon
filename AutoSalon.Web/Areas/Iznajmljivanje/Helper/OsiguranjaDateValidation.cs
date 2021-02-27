using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Iznajmljivanje.Helper
{
    public class OsiguranjaDateValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime uneseniDatum = (DateTime)value;

            if (uneseniDatum < DateTime.Now)
                return new ValidationResult("Datum mora biti veći od trenutnog");

            if (uneseniDatum > DateTime.Now.AddYears(5))
                return new ValidationResult("Nije moguće osigurati vozilo na više od 5 godina");

            return ValidationResult.Success;
        }
    }
}
