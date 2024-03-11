
using FluentValidation.AspNetCore;

namespace Cars.Application
{
    /// <summary>
    /// This class is used to register the application services in the DI container.
    /// </summary>
    public static class ApplicationServiceRegistration
    {
        /// <summary>
        /// IServiceCollection is a collection of service descriptors.
        /// It is inbuilt in the Microsoft.Extensions.DependencyInjection namespace.
        /// </summary>
        public static  IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}
