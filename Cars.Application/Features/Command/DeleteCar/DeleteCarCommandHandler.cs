using Cars.Application.Contracts.Persistence;
using Cars.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.DeleteCar
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork
        public DeleteCarCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;   
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var carToDelete = await _unitOfWork.Cars.GetFirstOrDefaultAsync(c=>c.Id==request.Id);
            if(carToDelete==null)
            {
                throw new CarNotFoundException();
            }
            await _unitOfWork.Cars.DeleteAsync(carToDelete);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
