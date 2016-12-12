using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BootstrapMvc.Core.Extensions
{
    public static class ModelStateExtensions
    {
        public static string ToErrorMessage(this ModelStateDictionary modelState)
        {
            return string.Join("\n", modelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage));
        }

        public static IEnumerable<string> ToErrorMessages(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage);
        }
    }
}
