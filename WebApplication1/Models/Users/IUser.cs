using System;
using System.Collections.Generic;
using WebApplication1.Models.Orders;

namespace WebApplication1.Models.Users
{
    public interface IUser
    {
        int Id { get; }
        string Name { get; set; }
        DateTime Birthday { get; set; }
        List<Order> Orders { get;}
    }
}
