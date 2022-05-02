using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Orders;

namespace WebApplication1.Models.Users
{
    public class UserDTO
    {
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        public List<Order> Orders { get; private set; } = new();
    }
}
