using System;
using System.Collections.Generic;
using WebApplication1.Models.Products;

namespace WebApplication1.Models.Orders
{
    public class Order : IOrder
    {
        public int Id { get; private set; }

        public decimal TotalPrice { get; set; }

        public List<Product> Products { get; private set; }
        public DateTime Date { get; set; }
        public Order()
        {
            Products = new List<Product>();
        }
    }
}
