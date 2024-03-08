using Cars.UI.Models;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Cars.UI;
using Cars.UI.Services.Interfaces;
using Cars.UI.Services.Implementations;

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

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Host.UseSerilog();
builder.Services.AddHttpClient();

builder.Services.AddOptions<ApiUrlOptions>().BindConfiguration("ApiUrlOptions")
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddTransient<IBrandApiService, BrandApiService>();
builder.Services.AddTransient<ICarApiService, CarApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Brand}/{action=Index}/{id?}");

app.Run();
