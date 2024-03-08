using Cars.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Queries.GetBrandByCarId
{
    public class GetBrandByCarIdQueryHandler : IRequestHandler<GetBrandByCarIdQuery, BrandGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetBrandByCarIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BrandGetDto> Handle(GetBrandByCarIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.Cars.GetBrandByCarId(request.CarId);
            if(brand is null)
            {
                return null;
            }
            return _mapper.Map<BrandGetDto>(brand);
        }
    }
}
