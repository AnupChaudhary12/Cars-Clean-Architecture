
namespace Cars.Domain.Entities
{
    /// <summary>
    /// This class represents the Brand entity and contains the properties of the Brand
    /// </summary>
    public class Brand:BaseEntity
    {
        public string BrandName { get; set; } = default!;
        public string Country { get; set; } = default!; 
        
        // Navigation property for the related entities e.g. Car for 1 to many relationship
        public List<Car>? Cars { get; set; } 

    }
}
