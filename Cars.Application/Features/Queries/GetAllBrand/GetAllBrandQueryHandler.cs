using Cars.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Queries.GetAllBrand
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, List<BrandGetDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllBrandQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BrandGetDto>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            var brandList = await _unitOfWork.Brands.GetAllAsync();
            return _mapper.Map<List<BrandGetDto>>(brandList);
        }
    }
}
