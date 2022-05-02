using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Products
{
    public class ProductDTO
    {
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
