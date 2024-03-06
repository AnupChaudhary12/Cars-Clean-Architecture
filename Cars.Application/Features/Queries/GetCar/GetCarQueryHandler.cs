using Cars.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Queries.GetCar
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, CarGetDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetCarQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CarGetDto> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.Cars.GetFirstOrDefaultAsync(c=> c.Id==request.Id);
            return _mapper.Map<CarGetDto>(car);
        }
    }
}
