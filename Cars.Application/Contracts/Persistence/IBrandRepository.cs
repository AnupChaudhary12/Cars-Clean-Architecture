namespace Cars.Application.Contracts.Persistence
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<bool> IsBrandNameUnique(string brandName);
    }
}
