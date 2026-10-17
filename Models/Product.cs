
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Range(0, 100000)]
        public int Stock { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
