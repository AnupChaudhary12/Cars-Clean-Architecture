using Cars.Application.Contracts.Persistence;

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
            var car = _mapper.Map<Car>(request);
            await _unitOfWork.Cars.AddAsync(car);
            await _unitOfWork.Save();
            return car.Id;
        }
    }
}
