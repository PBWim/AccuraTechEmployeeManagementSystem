namespace Shared
{
    using Business;
    using Data.Models;
    using Data.Repository;
    using Data.Repository.Base;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Register the Services
            services.AddScoped<DepartmentService>();
            services.AddScoped<EmployeeService>();

            // Register the Repositories
            services.AddScoped<DepartmentRepository>();
            services.AddScoped<EmployeeRepository>();
        }
    }
}