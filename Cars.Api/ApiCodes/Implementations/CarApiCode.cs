using Cars.Api.ApiCodes.Interfaces;
using Cars.Application.Contracts.DTOs;
using MediatR;

namespace Cars.Api.ApiCodes.Implementations
{
    public class CarApiCode : ICarsApiCode
    {
        public Task<IResult> AddCar(IMediator mediator, CarCreateDto carCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteCar(IMediator mediator, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetAllCars(IMediator mediator)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetCarById(IMediator mediator, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateCar(IMediator mediator, int id)
        {
            throw new NotImplementedException();
        }
    }
}
