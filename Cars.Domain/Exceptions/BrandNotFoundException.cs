using Cars.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Exceptions
{
    public class BrandNotFoundException:SharedExceptions
    {
        public BrandNotFoundException():base("Brand Not Found")
        {
            
        }
    }
}
