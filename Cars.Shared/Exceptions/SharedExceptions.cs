using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Shared.Exceptions
{
    public abstract class SharedExceptions:Exception
    {
        protected SharedExceptions(string message ):base(message)
        {
            
        }
    }
}
