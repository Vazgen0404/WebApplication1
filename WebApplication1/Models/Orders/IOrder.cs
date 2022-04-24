using System;
using System.Collections.Generic;
using WebApplication1.Models.Products;

namespace WebApplication1.Models.Orders
{
    public interface IOrder
    {
        int Id { get;}
        decimal TotalPrice { get; set; }
        DateTime Date { get; set; } 
        List<Product> Products { get;}

    }
}
