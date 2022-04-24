using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ActionResult<TEntity>> Get(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetAll();
        Task<int> Add(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(int id);
        bool Exists(int id);
    }
}
