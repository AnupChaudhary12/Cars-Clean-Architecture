using Asp.Versioning;
using Asp.Versioning.Conventions;
using Cars.Api.ApiCodes.Implementations;
using Cars.Api.ApiCodes.Interfaces;
using Microsoft.AspNetCore.Builder;

namespace Cars.Api.Extensions
{
    public static class MapApis
    {
        public static void MapBrandsApi(this WebApplication app, BrandApiCode brandApiCode)
        {
            //var versionSet = app.NewApiVersionSet()
            //    .HasApiVersion(new ApiVersion(1,0));

            var versionSet = app.NewApiVersionSet()
                .HasApiVersion(1) // Shows the version 1 as supported
                .HasApiVersion(2, 0) // Shows the version 2 as supported
                .ReportApiVersions() // shows the version in the response header ans shows which version is supported
                .Build();

            // if we want api version inside the endpoint itself
            // app.MapGet("hello",(HttpContext context) =>
            // {
               //     var version = context.GetRequestedApiVersion();
               //     return Results.Ok($"Hello from version {version}");
               //});

            // output : Hello from version 1.0


            // for url segment versioning we have to use v{version:apiVersion}
            //var brands = app.MapGroup("v{api:apiVersion}/api/Brands")
            var brands = app.MapGroup("/api/Brands")
                //.WithApiVersionSet(versionSet)
                //.MapToApiVersion(2)
                .WithTags("Brands Api");

            brands.MapGet("GetAllBrands", brandApiCode.GetAllBrands);
            //.WithApiVersionSet(versionSet)
            //.MapToApiVersion(2);
            brands.MapPost("AddBrand", brandApiCode.AddBrand);
                //.WithApiVersionSet(versionSet)
                //.MapToApiVersion(1);
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
