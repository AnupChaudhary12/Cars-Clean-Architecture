namespace Cars.Application.Contracts.DTOs
{
    public class CarCreateDto
    {
        public string CarModel { get; set; } = default!;
        public string Color { get; set; } = default!;
        public int TyreCount { get; set; }
        public string NumberPlate { get; set; } = default!;
        public int BrandId { get; set; }
    }
}
