using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Queries.ListCarsByBrand
{
    public class GetCarsByBrandQuery: IRequest<List<CarGetDto>>
    {
        public int Id { get; set; }
    }
}
