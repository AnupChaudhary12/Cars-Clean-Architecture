namespace Cars.Application.Features.Queries.GetCar
{
    public record GetCarQuery(int Id):IRequest<CarGetDto>
    {

    }
}
