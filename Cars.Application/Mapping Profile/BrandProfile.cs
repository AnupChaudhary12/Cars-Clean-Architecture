namespace Cars.Application.Mapping_Profile
{
    public class BrandProfile: Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandCreateDto>().ReverseMap();
            CreateMap<Brand,BrandGetDto>().ReverseMap();
        }
    }
}
