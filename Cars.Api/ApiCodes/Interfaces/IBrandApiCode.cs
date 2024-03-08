using Cars.Application.Contracts.DTOs;
using Cars.Application.Features.Command.CreateBrand;
using Cars.Application.Features.Command.DeleteBrand;
using Cars.Application.Features.Command.UpdateBrand;
using MediatR;

namespace Cars.Api.ApiCodes.Interfaces
{
    public interface IBrandApiCode
    {
        Task<IResult> GetAllBrands(IMediator mediator);
        Task<IResult> AddBrand(IMediator mediator, CreateBrandCommand createBrand);
        Task<IResult> DeleteBrand(IMediator mediator, int id);
        Task<IResult> UpdateBrand(IMediator mediator,UpdateBrandCommand updateBrand);
        Task<IResult> GetBrandById(IMediator mediator, int id);
        Task<IResult> GetCarsByBrandId(IMediator mediator, int brandId);

    }
}
