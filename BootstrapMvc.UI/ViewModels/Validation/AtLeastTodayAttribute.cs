using System;
using System.ComponentModel.DataAnnotations;

namespace BootstrapMvc.UI.ViewModels.Validation
{
    public class AtLeastTodayAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;

            if (DateTime.TryParse(value.ToString(), out date))
                return date >= DateTime.Now.Date;

            return false;
        }
    }
}
