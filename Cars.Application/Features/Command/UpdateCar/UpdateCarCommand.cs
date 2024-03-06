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
    }
}
