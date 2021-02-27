using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.Helper
{
    public class DostavaKDateValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime uneseniDatum = (DateTime)value;

            if (uneseniDatum > DateTime.Now.AddDays(45).Date)
                return new ValidationResult("Neispravan unos. Krajnji datum dostave mora biti u roku 45 dana.");

            if (uneseniDatum < DateTime.Now.AddDays(30).Date)
                return new ValidationResult("Neispravan unos.");

            return ValidationResult.Success;
        }
    }
}
