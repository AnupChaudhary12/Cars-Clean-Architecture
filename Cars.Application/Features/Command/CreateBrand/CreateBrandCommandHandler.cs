using Cars.Application.Contracts.Persistence;
using Cars.Application.Validators.Brands;
using Cars.Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var validator = new CreateBrandCommandValidator(_unitOfWork);
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                throw new ValidationExceptions("Invalid Brand",validatorResult);
            }
            var brandToCreate = _mapper.Map<Brand>(request);
            await _unitOfWork.Brands.AddAsync(brandToCreate);
            await _unitOfWork.Save();
            return brandToCreate.Id;
        }
    }
}
