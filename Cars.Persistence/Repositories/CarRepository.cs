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
        public async Task<bool> IsCarModelUnique(string carModel)
        {
            return await _dbContext.Cars.AnyAsync(c=>c.CarModel==carModel) == false;
        }
    }
}
