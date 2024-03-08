using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.UpdateCar
{
    public class UpdateCarCommand: IRequest<int>
    {
        public  int Id { get; set; }
        public string CarModel { get; set; } = default!;
        public string Color { get; set; } = default!;
        public int TyreCount { get; set; } = default!;
        public string NumberPlate { get; set; } = default!;
        public int BrandId { get; set; }
    }
}
