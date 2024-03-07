using Cars.Application.Features.Command.CreateBrand;
using Cars.Application.Features.Command.UpdateBrand;

namespace Cars.Application.Mapping_Profile
{
    public class BrandProfile: Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>()
               .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName))
               .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
               .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Id during mapping from command to entity
            CreateMap<Brand, BrandGetDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.BrandName))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
            CreateMap<UpdateBrandCommand, Brand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
        }
    }
}
