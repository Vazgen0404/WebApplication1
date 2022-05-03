using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface IUserRepository<User> : IRepository<User> where User : class
    {
        Task<User> UserWithMaxOrders();
    }
}
