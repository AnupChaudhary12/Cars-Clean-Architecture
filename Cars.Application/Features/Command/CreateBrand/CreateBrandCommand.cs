using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Features.Command.CreateBrand
{
    public class CreateBrandCommand: IRequest<int>
    {
        // when using this i get 
//        {
//  "brandCreateDto": {
//    "brandName": "string",
//    "country": "string"
//  }
//}
    //public BrandCreateDto? BrandCreateDto { get; set; }


    // so better to use 
    
        public string BrandName { get; set; }=default!;
        public string Country { get; set; }=default!;
    }
}
