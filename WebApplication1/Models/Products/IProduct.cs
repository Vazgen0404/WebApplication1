using WebApplication1.Models.Orders;

namespace WebApplication1.Models.Products
{
    public interface IProduct
    {
        int Id { get;}
        string Name { get; set; }
        decimal Price { get; set; }
        Order Order { get; set; }
    }
}
