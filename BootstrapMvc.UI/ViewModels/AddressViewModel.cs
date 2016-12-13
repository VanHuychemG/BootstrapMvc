using System.ComponentModel.DataAnnotations;

namespace BootstrapMvc.UI.ViewModels
{
    public class AddressViewModel
    {
        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string ZipCode { get; set; }
    }
}
