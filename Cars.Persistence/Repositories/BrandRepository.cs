using Cars.Application.Contracts.Persistence;
using Cars.Domain.Entities;
using Cars.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Cars.Persistence.Repositories
{
    public class BrandRepository : GenericRepository<Brand>,IBrandRepository
    {
        private readonly CarBrandDbContext _dbContext;
        public BrandRepository(CarBrandDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsBrandNameUnique(string brandName)
        {
            return await _dbContext.Brands.AnyAsync(b => b.BrandName == brandName) == false;
        }
    }
}
