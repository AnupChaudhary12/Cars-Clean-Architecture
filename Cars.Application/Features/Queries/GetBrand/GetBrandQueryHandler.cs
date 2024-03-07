using Cars.Application.Contracts.Persistence;

namespace Cars.Application.Features.Queries.GetBrand
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, BrandGetDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetBrandQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BrandGetDto> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.Brands.GetFirstOrDefaultAsync(b => b.Id == request.Id);
            return _mapper.Map<BrandGetDto>(brand);
        }
    }
}
