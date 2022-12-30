namespace Data
{
    using Data.Models;

    public class DbInitializer
    {
        /// <summary>
        /// Default Departments in the System
        /// </summary>
        private static readonly List<string> defaultDepartments = new()
        {
            "General Management",
            "Marketing Department",
            "Operations Department",
            "Finance Department",
            "Sales Department",
            "Human Resource Department",
            "Information and Technology Department"
        };

        /// <summary>
        /// Seed default data to the Database
        /// </summary>
        /// <param name="context"></param>
        public static void InitializeDatabase(DataContext context)
        {
            SeedDepartments(context);
        }

        /// <summary>
        /// Seed Default Departments to the Database
        /// </summary>
        private static void SeedDepartments(DataContext context)
        {
            if (!context.Departments.Any())
            {
                foreach (var item in defaultDepartments)
                {
                    var department = new Department
                    {
                        Id = new Guid(),
                        Name = item
                    };
                    context.Departments.Add(department);
                }
                context.SaveChanges();
            }
        }
    }
}