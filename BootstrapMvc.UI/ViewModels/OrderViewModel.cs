using System;
using System.ComponentModel.DataAnnotations;

namespace BootstrapMvc.UI.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
