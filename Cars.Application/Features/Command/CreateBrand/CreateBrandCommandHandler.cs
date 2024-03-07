using Cars.Application.Contracts.Persistence;
using Cars.Application.Validators.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var validator = new BrandCreateDtoValidator(_unitOfWork);
            var validatorResult = await validator.ValidateAsync(request.BrandCreateDto);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException("Invalid Brand", (IEnumerable<FluentValidation.Results.ValidationFailure>)validatorResult);
            }
            var brandToCreate = _mapper.Map<Brand>(request.BrandCreateDto);
            await _unitOfWork.Brands.AddAsync(brandToCreate);
            await _unitOfWork.Save();
            return brandToCreate.Id;
        }
    }
}
