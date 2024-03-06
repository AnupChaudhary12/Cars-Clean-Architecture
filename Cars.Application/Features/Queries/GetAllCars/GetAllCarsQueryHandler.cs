using Cars.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Queries.GetAllCars
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<CarGetDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCarsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CarGetDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var allCars = await _unitOfWork.Cars.GetAllAsync();

            // Convert the result to List<CarGetDto>
            var cars =  _mapper.Map<List<CarGetDto>>(allCars);

            // Return the result
            return cars;
        }
    }
}
