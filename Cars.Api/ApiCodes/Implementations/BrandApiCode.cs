using Cars.Api.ApiCodes.Interfaces;
using Cars.Application.Contracts.DTOs;
using Cars.Application.Features.Command.CreateBrand;
using Cars.Application.Features.Command.DeleteBrand;
using Cars.Application.Features.Command.UpdateBrand;
using Cars.Application.Features.Queries.GetAllBrand;
using Cars.Application.Features.Queries.GetBrand;
using MediatR;

namespace Cars.Api.ApiCodes.Implementations
{
    public class BrandApiCode : IBrandApiCode
    {
        public async Task<IResult> AddBrand(IMediator mediator,CreateBrandCommand createBrand)
        {
            var response = await mediator.Send(createBrand);
            return TypedResults.Created(nameof(GetAllBrands), new { id = response });
        }

        public async Task<IResult> DeleteBrand(IMediator mediator, int id)
        {
            var deleteBrand = new DeleteBrandCommand { Id = id};
            await mediator.Send(deleteBrand);
            return TypedResults.Ok("Deleted Succesfully");
        }

        public async Task<IResult> GetAllBrands(IMediator mediator)
        {
            return TypedResults.Ok(await mediator.Send(new GetAllBrandQuery()));
        }

        public async Task<IResult> GetBrandById(IMediator mediator, int id)
        {
            var brandById= await mediator.Send(new GetBrandQuery(id));
            return TypedResults.Ok(brandById);
        }

        public async Task<IResult> UpdateBrand(IMediator mediator,UpdateBrandCommand updateBrand)
        {
             await mediator.Send(updateBrand);
            return TypedResults.Ok("Updated Succesfully");
        }
    }
}
