using Cars.Application.Contracts.Persistence;
using Cars.Application.Features.Command.CreateBrand;

namespace Cars.Application.Validators.Brands
{
    public class CreateBrandCommandValidator: AbstractValidator<CreateBrandCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBrandCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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
            if (_unitOfWork == null || _unitOfWork.Brands == null)
            {
                // Log or handle the null reference appropriately
                return false;
            }

            return await _unitOfWork.Brands.IsBrandNameUnique(brandName);
        }
    }
}
