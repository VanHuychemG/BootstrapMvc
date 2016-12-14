using System;
using System.ComponentModel.DataAnnotations;

namespace BootstrapMvc.UI.ViewModels.Validation
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;

            if (DateTime.TryParse(value.ToString(), out date))
                return date.AddYears(_minimumAge) < DateTime.Now;

            return false;
        }
    }
}
