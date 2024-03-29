using Asp.Versioning;
using Cars.Api.ApiCodes.Implementations;
using Cars.Api.ApiCodes.Interfaces;
using Cars.Api.Extensions;
using Cars.Api.OpenApi;
using Cars.Application;
using Cars.Infrastructure;
using Cars.Persistence;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Swashbuckle.AspNetCore.SwaggerGen;


Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
           .Enrich.WithThreadId()
           .Enrich.WithProcessId()
           .Enrich.WithEnvironmentName()
           .Enrich.WithMachineName()
           .WriteTo.Console(new CompactJsonFormatter())
           .WriteTo.File(new CompactJsonFormatter(), "Log/log.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();

Log.Logger.Information("Logger is working fine");

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options=>options.OperationFilter<SwaggerDefaultValues>());

// To show which version is supported and which is depreciated using options
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.AssumeDefaultVersionWhenUnspecified = true;
    // what if we want to use version type like media type , header or httproute parameter
    //options.ApiVersionReader = new QueryStringApiVersionReader();
    //options.ApiVersionReader = new HeaderApiVersionReader("api-version");
    //options.ApiVersionReader = new MediaTypeApiVersionReader();
    //if we want to use the version from the url itself
    //options.ApiVersionReader = new UrlSegmentApiVersionReader();

}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseHttpsRedirection();

var brandApiCode = new BrandApiCode();
app.MapBrandsApi(brandApiCode);

var carApiCode = new CarApiCode();
app.MapCarsApi(carApiCode);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		var descriptions = app.DescribeApiVersions();

		// Build a swagger endpoint for each discovered API version
		foreach (var description in descriptions)
		{
			var url = $"/swagger/{description.GroupName}/swagger.json";
			var name = description.GroupName.ToUpperInvariant();
			options.SwaggerEndpoint(url, name);
		}
	});
}




app.Run();
