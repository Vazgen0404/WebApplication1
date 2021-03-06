using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;
using WebApplication1.Models.Orders;

namespace WebApplication1.Models.Products
{
    public class Product : IProduct
    {
        public int Id { get; private set; }

        [Required]
        public string Name { get ; set; }
        [Required]
        public decimal Price { get; set; }
        public Order Order { get; set; }
    }
}
