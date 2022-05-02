using AutoMapper;
using WebApplication1.Models.Orders;
using WebApplication1.Models.Products;
using WebApplication1.Models.Users;

namespace WebApplication1.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Order,OrderDTO>().ReverseMap();
        }
    }
}
