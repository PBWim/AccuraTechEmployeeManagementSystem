namespace Shared
{
    using Business;
    using Data.Repository;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceConfig
    {
        /// <summary>
        /// Register Dependencies
        /// </summary>
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