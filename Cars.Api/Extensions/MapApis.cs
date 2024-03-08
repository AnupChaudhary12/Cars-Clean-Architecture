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
            brands.MapGet("GetBrandById/{id}", brandApiCode.GetBrandById);
            brands.MapGet("GetCarsByBrandId/{brandId}", brandApiCode.GetCarsByBrandId);
        }

        public static void MapCarsApi(this WebApplication app, CarApiCode carApiCode)
        {
            var cars = app.MapGroup("/api/Cars")
                .WithTags("Cars Api");

            cars.MapGet("GetAllCars", carApiCode.GetAllCars);
            cars.MapPost("AddCar", carApiCode.AddCar);
            cars.MapPut("UpdateCar", carApiCode.UpdateCar);
            cars.MapDelete("DeleteCar/{id}", carApiCode.DeleteCar);
            cars.MapGet("GetCarById/{id}", carApiCode.GetCarById);
            cars.MapGet("GetBrandByCarId/{carId}", carApiCode.GetBrandByCarId);
        }
    }
}
