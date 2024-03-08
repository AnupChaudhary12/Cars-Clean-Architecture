using Cars.Application.Features.Command.CreateCar;
using Cars.Application.Features.Command.UpdateCar;

namespace Cars.Application.Mapping_Profile
{
    public class CarProfile: Profile
    {
        public CarProfile()
        {
            CreateMap<Car,CarGetDto>().ReverseMap();
            CreateMap<CreateCarCommand,Car>().ReverseMap();
            CreateMap<UpdateCarCommand,Car>().ReverseMap();
        }
    }
}
