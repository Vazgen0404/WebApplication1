using System;
using System.Collections.Generic;
using WebApplication1.Models.Orders;

namespace WebApplication1.Models.Users
{
    public class User : IUser
    {
        public int Id { get; private set; }

        public string Name { get; set ; }
        public DateTime Birthday { get; set; }

        public List<Order> Orders { get; private set; }

        public User()
        {
            Orders = new List<Order>();
        }
    }
}
