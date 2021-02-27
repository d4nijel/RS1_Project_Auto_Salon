using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.Helper
{
    public class KlijentDateValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime uneseniDatum = (DateTime)value;

            if(uneseniDatum > DateTime.Now.AddYears(-18).Date)
                return new ValidationResult("Klijent mora biti punoljetan");

            if (uneseniDatum <= new DateTime(1900, 1, 1))
                return new ValidationResult("Datum mora biti veći od 1/1/1900");

            return ValidationResult.Success;
        }
    }
}
