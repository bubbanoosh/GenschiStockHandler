using AutoMapper;

namespace GenschiStockHandler.API.Helpers{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Product, Dtos.ProductListDto>();
            // .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
            //     $"{src.FirstName} {src.LastName}"));

            CreateMap<Entities.Product, Dtos.ProductDetailDto>();

            // CreateMap<Entities.User, Dtos.UserDisplayDto>();

            // CreateMap<Entities.User, Dtos.UserDto>();
            // CreateMap<Dtos.UserDto, Entities.User>();
        }
    }
}
