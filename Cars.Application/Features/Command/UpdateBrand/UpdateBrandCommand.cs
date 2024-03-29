﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.UpdateBrand
{
    public class UpdateBrandCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = default!;
        public string Country { get; set; } = default!;
    }
}
