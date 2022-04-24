using WebApplication1.Models;
using WebApplication1.Models.Orders;

namespace WebApplication1.Models.Products
{
    public class Product : IProduct
    {
        public int Id { get; private set; }

        public string Name { get ; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
    }
}
