
namespace Cars.Domain.Entities
{
    /// <summary>
    /// This class represents a car entity and contains all the properties of a car.
    /// </summary>
    public class Car: BaseEntity
    {
        public string CarModel { get; set; } = default!;
        public string Color { get; set; } = default!;
        public int TyreCount { get; set; }
        public string NumberPlate { get; set; } = default!;

        // Foreign Key
        public int BrandId { get; set; }
        public Brand? Brand { get; set; } = default!;
    }
}
