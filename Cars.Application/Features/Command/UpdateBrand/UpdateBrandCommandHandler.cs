using Cars.Application.Contracts.Persistence;
using Cars.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandToUpdate = await _unitOfWork.Brands.GetFirstOrDefaultAsync(b=>b.Id == request.Id);
            if (brandToUpdate == null)
            {
                throw new BrandNotFoundException();
            }
            else
            {
                var mappedBrand = _mapper.Map<Brand>(brandToUpdate);
                await _unitOfWork.Brands.UpdateAsync(mappedBrand);
                await _unitOfWork.Save();
                return mappedBrand.Id;
            }
        }
    }
}
