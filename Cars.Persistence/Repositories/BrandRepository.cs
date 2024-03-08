using Cars.Application.Contracts.DTOs;
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

        public void DetachBrandEntity(Brand brand)
        {
            var entry = _dbContext.Entry(brand);
            entry.State = EntityState.Detached;
        }

        public async Task<bool> IsBrandNameUnique(string brandName)
        {
            return await _dbContext.Brands.AnyAsync(b => b.BrandName == brandName) == false;
        }

        public async Task<List<Car>> ListCarsByBrand(int id)
        {
            var carList = await _dbContext.Brands.Include(b => b.Cars)
                .FirstOrDefaultAsync(b => b.Id == id);
            if(carList != null)
            {
				return carList.Cars.ToList();
			}
            return null;

        }
    }
}
