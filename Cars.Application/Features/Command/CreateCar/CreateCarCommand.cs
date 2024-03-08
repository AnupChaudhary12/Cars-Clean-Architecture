namespace Cars.Application.Features.Command.CreateCar
{
    public class CreateCarCommand: IRequest<int>
    {
        // We can pass properties which we write in DTo like this without creating new DTo class
        public string CarModel { get; set; } = default!;
        public string Color { get; set; } = default!;
        public int TyreCount { get; set; } = default!;
        public string NumberPlate { get; set; } = default!;
        public int BrandId { get; set; }

        // OR 
        //public CarCreateDto? CreateCarsDto { get; set; }
    }
}
