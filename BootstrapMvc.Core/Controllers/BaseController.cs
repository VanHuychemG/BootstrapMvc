using System.Collections.Generic;
using System.Linq;

using BootstrapMvc.Core.Extensions;
using BootstrapMvc.Core.Helpers;

using Microsoft.AspNetCore.Mvc;

namespace BootstrapMvc.Core.Controllers
{
    public class BaseController : Controller
    {
        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, IEnumerable<string> errorMessages = null, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message, dismissable, errorMessages);
        }

        public void Danger(string message, IEnumerable<string> errorMessages = null, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, message, dismissable, errorMessages);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable, IEnumerable<string> errorMessages = null)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable,
                ModelStateErrors = errorMessages?.ToList() ?? new List<string>()
            });

            TempData.SetAsJson(Alert.TempDataKey, alerts);
        }
    }
}
