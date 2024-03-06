namespace Cars.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IBrandRepository Brands { get; }
        ICarRepository Cars { get; }
        Task Save();
    }
}
