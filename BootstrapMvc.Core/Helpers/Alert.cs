using System.Collections.Generic;

namespace BootstrapMvc.Core.Helpers
{
    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";

        public string AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
        public IList<string> ModelStateErrors { get; set; }
    }
}
