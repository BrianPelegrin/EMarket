using AutoMapper;
using TecnoMarket.Core.Entities;
using TecnoMarket.Core.ViewModels;

namespace TecnoMarket.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Statu, StatuViewModel>().ReverseMap();


        }
    }
}
