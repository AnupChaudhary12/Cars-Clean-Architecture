using Cars.Application.Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.ApiCodes.Interfaces
{
    public interface ICarsApiCode
    {
        Task<IResult> GetAllCars(IMediator mediator);
        Task<IResult> AddCar(IMediator mediator, CarCreateDto carCreateDto);
        Task<IResult> DeleteCar(IMediator mediator, int id);
        Task<IResult> UpdateCar(IMediator mediator, int id);
        Task<IResult> GetCarById(IMediator mediator, int id);
    }
}
