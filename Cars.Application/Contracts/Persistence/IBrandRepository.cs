namespace Cars.Application.Contracts.Persistence
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<bool> IsBrandNameUnique(string brandName);
        void DetachBrandEntity(Brand brand);
        Task<List<Car>> ListCarsByBrand(int id);
    }
}
