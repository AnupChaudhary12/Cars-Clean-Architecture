using Cars.Application.Contracts.DTOs;
using Cars.Application.Features.Command.CreateCar;
using Cars.Application.Features.Command.UpdateCar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.ApiCodes.Interfaces
{
    public interface ICarsApiCode
    {
        Task<IResult> GetAllCars(IMediator mediator);
        Task<IResult> AddCar(IMediator mediator, CreateCarCommand createCar);
        Task<IResult> DeleteCar(IMediator mediator, int id);
        Task<IResult> UpdateCar(IMediator mediator, UpdateCarCommand updateCar);
        Task<IResult> GetCarById(IMediator mediator, int id);
        Task<IResult> GetBrandByCarId(IMediator mediator, int carId);
        
    }
}
