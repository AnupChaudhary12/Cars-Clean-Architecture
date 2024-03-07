using Cars.Api.ApiCodes.Implementations;
using Cars.Api.ApiCodes.Interfaces;
using Microsoft.AspNetCore.Builder;

namespace Cars.Api.Extensions
{
    public static class MapApis
    {
        public static void MapBrandsApi(this WebApplication app, BrandApiCode brandApiCode)
        {
            var brands = app.MapGroup("/api/Brands")
                .WithTags("Brands Api");

            brands.MapGet("GetAllBrands", brandApiCode.GetAllBrands);
            brands.MapPost("AddBrand", brandApiCode.AddBrand);
            brands.MapPut("UpdateBrand", brandApiCode.UpdateBrand);
            brands.MapDelete("DeleteBrand/{id}", brandApiCode.DeleteBrand);
            brands.MapGet("GetCarByBrand/{id}", brandApiCode.GetBrandById);
        }
    }
}
