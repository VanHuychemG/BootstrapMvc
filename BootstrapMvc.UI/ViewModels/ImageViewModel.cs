using System.ComponentModel.DataAnnotations;

namespace BootstrapMvc.UI.ViewModels
{
    public class ImageViewModel
    {
        [Required]
        public string Base64 { get; set; }
    }
}
