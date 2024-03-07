namespace Cars.Application.Contracts.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        IBrandRepository Brands { get; }
        ICarRepository Cars { get; }
        Task Save();
    }
}
