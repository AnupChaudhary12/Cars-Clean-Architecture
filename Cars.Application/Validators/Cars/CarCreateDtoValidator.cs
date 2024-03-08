
using Cars.Application.Contracts.Persistence;
using Cars.Application.Features.Command.CreateCar;

namespace Cars.Application.Validators.Cars
{
    public class CarCreateDtoValidator: AbstractValidator<CreateCarCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarCreateDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            RuleFor(p=>p.CarModel).NotEmpty().WithMessage("Car Model is required")
                .NotNull()
                .MustAsync(UniqueModelName).WithMessage("Car Model already exists")
                .MaximumLength(50).WithMessage("Car Model must not exceed 50 characters");
            RuleFor(p=>p.Color).NotEmpty().WithMessage("Color is required")
                .NotNull()
                .MaximumLength(50).WithMessage("Color must not exceed 50 characters");
            RuleFor(p=>p.TyreCount).NotEmpty().WithMessage("Tyre Count is required")
                .NotNull()
                .GreaterThan(0).WithMessage("Tyre Count must be greater than 0");
            RuleFor(p=>p.NumberPlate).NotEmpty().WithMessage("Number Plate is required")
                .NotNull()
                .MaximumLength(50).WithMessage("Number Plate must not exceed 50 characters");
            RuleFor(p=>p.BrandId).NotEmpty().WithMessage("Brand is required")
                .NotNull()
                .GreaterThan(0).WithMessage("Brand must be greater than 0");
        }

        private async Task<bool> UniqueModelName(string carModel, CancellationToken token)
        {
            if(_unitOfWork == null || _unitOfWork.Cars == null)
            {
                return false;
            }
            return await _unitOfWork.Cars.IsCarModelUnique(carModel);
        }
    }
}
