using Cars.Application.Contracts.Persistence;
using Cars.Application.Validators.Cars;
using Cars.Domain.Exceptions;

namespace Cars.Application.Features.Command.CreateCar
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCarCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var validator = new CarCreateDtoValidator(_unitOfWork);
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                throw new ValidationExceptions("Invalid car", validatorResult);
            }


            // if we are using DTo then we have to write like this           
            var car = _mapper.Map<Car>(request);

            // if we are not using DTo then we have to write like this
            //var car = _mapper.Map<Car>(request);

            await _unitOfWork.Cars.AddAsync(car);
            await _unitOfWork.Save();
            return car.Id;
        }
    }
}
