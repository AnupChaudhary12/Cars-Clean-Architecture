using Cars.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Validators.Brands
{
    public class BrandCreateDtoValidator: AbstractValidator<BrandCreateDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandCreateDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p=>p.BrandName).NotEmpty().WithMessage("Brand Name is required")
                .NotNull()
                .MustAsync(IsBrandNameUnique).WithMessage("Brand Name already exists")
                .MaximumLength(50).WithMessage("Brand Name must not exceed 50 characters");
            RuleFor(p=>p.Country).NotEmpty().WithMessage("Country is required")
                .NotNull()
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters");

        }

        private async Task<bool> IsBrandNameUnique(string brandName, CancellationToken token)
        {
            return await _unitOfWork.Brands.IsBrandNameUnique(brandName);
        }
    }
}
