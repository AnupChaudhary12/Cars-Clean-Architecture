namespace Cars.Application.Features.Queries.GetAllCars
{
    public class GetAllCarsQuery:IRequest<List<CarGetDto>>
    {
    }

    // Or we can use record also
    //public record GetAllCarsQuery : IRequest<List<CarGetDto>>
    //{

    //};
}
