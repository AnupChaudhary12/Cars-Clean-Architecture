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
            var validatorResult = await validator.ValidateAsync(request.CreateCarsDto);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException("Invalid car", (IEnumerable<FluentValidation.Results.ValidationFailure>)validatorResult);
            }


            // if we are using DTo then we have to write like this
            var carDto = request.CreateCarsDto;            
            var car = _mapper.Map<Car>(carDto);

            // if we are not using DTo then we have to write like this
            //var car = _mapper.Map<Car>(request);

            await _unitOfWork.Cars.AddAsync(car);
            await _unitOfWork.Save();
            return car.Id;
        }
    }
}
