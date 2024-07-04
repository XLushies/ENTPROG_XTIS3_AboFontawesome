using AutoMapper;
using ENTPROG_XTIS3_Abo.Models;

namespace ENTPROG_XTIS3_Abo.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Products, ProductsViewModel>().ReverseMap();
        }

    }
}
