using Cars.Application.Contracts.Persistence;
using Cars.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBrandCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;   
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brandToDelete = await _unitOfWork.Brands.GetFirstOrDefaultAsync(b=>b.Id==request.Id);
            if(brandToDelete==null)
            {
                throw new BrandNotFoundException();
            }
            await _unitOfWork.Brands.DeleteAsync(brandToDelete);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
