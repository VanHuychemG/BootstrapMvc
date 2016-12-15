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

        public OrderViewModel()
        {
            Price = 0;
            CreationDate = DateTime.Today;
        }
    }
}
