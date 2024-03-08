using Cars.Api.ApiCodes.Interfaces;
using Cars.Application.Contracts.DTOs;
using Cars.Application.Features.Command.CreateCar;
using Cars.Application.Features.Command.DeleteCar;
using Cars.Application.Features.Command.UpdateCar;
using Cars.Application.Features.Queries.GetAllCars;
using Cars.Application.Features.Queries.GetBrandByCarId;
using Cars.Application.Features.Queries.GetCar;
using MediatR;

namespace Cars.Api.ApiCodes.Implementations
{
    public class CarApiCode : ICarsApiCode
    {
        public async Task<IResult> AddCar(IMediator mediator, CreateCarCommand createCar)
        {
            var response = await mediator.Send(createCar);
            return TypedResults.Created(nameof(GetAllCars), new { id = response });
        }

        public async Task<IResult> DeleteCar(IMediator mediator, int id)
        {
            await mediator.Send(new DeleteCarCommand { Id=id});
            return TypedResults.Ok("Car details deleted Succesfully");
        }

        public async Task<IResult> GetAllCars(IMediator mediator)
        {
            return TypedResults.Ok(await mediator.Send(new GetAllCarsQuery()));
        }

        public async Task<IResult> GetBrandByCarId(IMediator mediator, int carId)
        {
            return TypedResults.Ok(await mediator.Send(new GetBrandByCarIdQuery { CarId =carId}));
        }

        public async Task<IResult> GetCarById(IMediator mediator, int id)
        {
            var response = await mediator.Send(new GetCarQuery(id));
            return TypedResults.Ok(response);
        }

        public async Task<IResult> UpdateCar(IMediator mediator, UpdateCarCommand updateCar)
        {
            await mediator.Send(updateCar);
            return TypedResults.Ok("Car Details Updated Succesfully");
        }
    }
}
