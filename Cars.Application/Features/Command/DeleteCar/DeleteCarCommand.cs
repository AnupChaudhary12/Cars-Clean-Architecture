using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.DeleteCar
{
    public class DeleteCarCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
