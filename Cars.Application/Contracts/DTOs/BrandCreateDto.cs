﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Contracts.DTOs
{
    public class BrandCreateDto
    {
        public string BrandName { get; set; } = default!;
        public string Country { get; set; } = default!;
    }
}
