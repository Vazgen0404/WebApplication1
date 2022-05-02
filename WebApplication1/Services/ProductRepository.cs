using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models.Products;

namespace WebApplication1.Services
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly MyDbContext _context;
        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Product entity)
        {
            _context.Products.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var Product = _context.Products.FirstOrDefault(x => x.Id == id);

            _context.Products.Remove(Product);
            return await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Include(p => p.Order).ToListAsync();
        }

        public async Task<int> Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
