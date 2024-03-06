
using Cars.Application.Contracts.Persistence;
using Cars.Domain.Exceptions;

namespace Cars.Application.Features.Command.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCarCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var carToUpdate = await _unitOfWork.Cars.GetFirstOrDefaultAsync(c=>c.Id == request.Id);
            if(carToUpdate == null)
            {
                throw new CarNotFoundException();
            }
            await _unitOfWork.Cars.UpdateAsync(carToUpdate);
            await _unitOfWork.Save();
            return carToUpdate.Id;
        }
    }
}
