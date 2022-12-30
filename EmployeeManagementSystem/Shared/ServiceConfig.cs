namespace Shared
{
    using Data.Models;
    using Data.Repository;
    using Data.Repository.Base;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Department>, DepartmentRepository>();
            services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>();
        }
    }
}