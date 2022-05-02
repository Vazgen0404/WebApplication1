using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Products;

namespace WebApplication1.Models.Orders
{
    public class Order : IOrder
    {
        public int Id { get; private set; }
        [Required]
        public decimal TotalPrice { get; set; }

        public List<Product> Products { get; private set; } = new();
        [Required]
        public DateTime Date { get; set; }
       
    }
}
