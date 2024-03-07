using Cars.Application.Features.Command.CreateCar;
using Cars.Application.Features.Command.UpdateCar;

namespace Cars.Application.Mapping_Profile
{
    public class CarProfile: Profile
    {
        public CarProfile()
        {
            CreateMap<CarGetDto, Car>().ReverseMap();
            CreateMap<Car,CarCreateDto>().ReverseMap(); 
            CreateMap<Car, UpdateCarCommand>().ReverseMap();
        }
    }
}
