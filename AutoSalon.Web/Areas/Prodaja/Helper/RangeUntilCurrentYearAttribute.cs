﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Areas.Prodaja.Helper
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RangeUntilCurrentYearAttribute : RangeAttribute
    {
        public RangeUntilCurrentYearAttribute(int minimum) : base(minimum, DateTime.Now.Year)
        {
        }
    }
}
