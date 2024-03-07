using Cars.Application.Contracts.Persistence;
using Cars.Persistence.DbContexts;

namespace Cars.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarBrandDbContext _dbContext;
        public UnitOfWork(CarBrandDbContext dbContext)
        {
            _dbContext = dbContext;
            Brands = new BrandRepository(_dbContext);
            Cars = new CarRepository(_dbContext);
        }
        public IBrandRepository Brands { get; private set; }

        public ICarRepository Cars { get; private set; }

        public void Dispose()
        {
            _dbContext.Dispose();            
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
