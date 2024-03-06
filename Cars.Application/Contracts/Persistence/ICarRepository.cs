namespace Cars.Application.Contracts.Persistence
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<bool> IsCarModelUnique(string carModel);
    }
}
