namespace Data
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class DataContext : DbContext
    {
        private readonly string connectionString;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString, builder => builder.EnableRetryOnFailure());
            }
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}