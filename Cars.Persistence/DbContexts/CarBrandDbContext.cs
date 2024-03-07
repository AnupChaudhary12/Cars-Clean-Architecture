using Cars.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Cars.Persistence.DbContexts
{
    public class CarBrandDbContext : DbContext
    {
        public CarBrandDbContext(DbContextOptions<CarBrandDbContext>options):base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
