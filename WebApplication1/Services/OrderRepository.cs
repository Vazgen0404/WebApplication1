using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models.Orders;

namespace WebApplication1.Services
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly MyDbContext _context;
        public OrderRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Order entity)
        {
            _context.Orders.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var Order = _context.Orders.FirstOrDefault(x => x.Id == id);

            _context.Orders.Remove(Order);
            return await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Order>> Get(int id)
        {
            return await _context.Orders.Include(u => u.Products).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return await _context.Orders.Include(u => u.Products).ToListAsync();
        }

        public async Task<int> Update(Order entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
