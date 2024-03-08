using Cars.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Queries.ListCarsByBrand
{
    public class GetCarsByBrandQueryHandler : IRequestHandler<GetCarsByBrandQuery, List<CarGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCarsByBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CarGetDto>> Handle(GetCarsByBrandQuery request, CancellationToken cancellationToken)
        {
            var cars = await _unitOfWork.Brands.ListCarsByBrand( request.Id);
            return _mapper.Map<List<CarGetDto>>(cars);
        }
    }
}
