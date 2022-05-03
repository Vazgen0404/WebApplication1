using System.Collections.Generic;
using WebApplication1.Context;
using WebApplication1.Models.Users;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly MyDbContext _context;
        public UserRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(User entity)
        {
            _context.Users.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.Include(u => u.Orders).ThenInclude(o => o.Products).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Include(u => u.Orders).ThenInclude(o => o.Products).ToListAsync();
        }

        public async Task<int> Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<User> UserWithMaxOrders()
        {
            var user = await _context.Users.Include(u => u.Orders).ThenInclude(o => o.Products).
                            OrderByDescending(u => u.Orders.Count).FirstAsync();
            return user;
        }
        public bool Exists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
