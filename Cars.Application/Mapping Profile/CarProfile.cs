namespace Cars.Application.Mapping_Profile
{
    public class CarProfile: Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarCreateDto>().ReverseMap();
            CreateMap<CarGetDto, Car>().ReverseMap();
        }
    }
}
