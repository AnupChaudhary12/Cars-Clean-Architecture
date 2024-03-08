using System.ComponentModel.DataAnnotations;

namespace Cars.UI.Models
{
    public class ApiUrlOptions
    {
        [Required]
        public string BrandsUrl { get; set; }=default!;
        [Required]
        public string CarsUrl { get; set; }=default!;
    }
}
