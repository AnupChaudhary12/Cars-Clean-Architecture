using Cars.Application.Contracts.Persistence;
using Cars.Domain.Entities;
using Cars.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Cars.Persistence.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    { 
        private readonly CarBrandDbContext _dbContext;
        public CarRepository(CarBrandDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void DetachCarEntity(Car car)
        {
            var entry = _dbContext.Entry(car);
            entry.State = EntityState.Detached;
        }

        public async Task<Brand> GetBrandByCarId(int carId)
        {
            var brandByCarId = await _dbContext.Cars.Include(b => b.Brand).FirstOrDefaultAsync(c=>c.Id == carId);
            if (brandByCarId == null)
            {
                return null;
            }
            return brandByCarId.Brand;
        }

        public async Task<bool> IsCarModelUnique(string carModel)
        {
            return await _dbContext.Cars.AnyAsync(c=>c.CarModel==carModel) == false;
        }
    }
}
