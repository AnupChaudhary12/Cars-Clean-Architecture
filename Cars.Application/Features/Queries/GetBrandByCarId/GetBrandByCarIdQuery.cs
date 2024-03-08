using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Queries.GetBrandByCarId
{
    public class GetBrandByCarIdQuery: IRequest<BrandGetDto>
    {
        public int CarId { get; set; }
    }
}
