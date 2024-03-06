namespace Cars.Application.Features.Command.CreateCar
{
    public class CreateCarCommand: IRequest<int>
    {
        public string Name { get; set; } = default!;
        public string Color { get; set; } = default!;
        public int TyreCount { get; set; }  = default!;
        public string NumberPlate { get; set; } = default!;
    }
}
