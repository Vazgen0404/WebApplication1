using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Orders
{
    public class OrderDTO
    {
        public int Id { get; private set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public List<int> Products { get; set; } = new();

    }
}
