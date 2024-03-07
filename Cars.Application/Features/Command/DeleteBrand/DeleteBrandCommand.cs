using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.DeleteBrand
{
    public class DeleteBrandCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
