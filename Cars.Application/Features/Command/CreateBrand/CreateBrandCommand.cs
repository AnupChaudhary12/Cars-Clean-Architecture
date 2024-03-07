using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.CreateBrand
{
    public class CreateBrandCommand: IRequest<int>
    {
        public BrandCreateDto? BrandCreateDto { get; set; }
    }
}
