namespace Data.Repository
{
    using System.Linq.Expressions;
    using Data.Models;
    using Data.Repository.Base;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeRepository : IBaseRepository<Employee>
    {
        private readonly DataContext context;

        /// <summary>
        /// Employee Repository - Handling the Employee model related CRUD operations
        /// </summary>
        public EmployeeRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all the Employees in the database
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetAll()
        {
            var employees = this.context.Employees.Include(i => i.Department).AsNoTracking();
            var employeeResult = employees.Select(a => new Employee
            {
                Id = a.Id,
                Address = a.Address,
                BasicSalary = a.BasicSalary,
                Department = new Department
                {
                    Id = a.Department.Id,
                    Name = a.Department.Name
                },
                DepartmentId = a.DepartmentId,
                DOB = a.DOB,
                FirstName = a.FirstName,
                Gender = a.Gender,
                LastName = a.LastName
            });
            return employeeResult;
        }

        /// <summary>
        /// Get Employee matching to the Search Criteria
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetByCondition(Expression<Func<Employee, bool>> expression)
        {
            var employees = this.context.Employees.Include(i => i.Department).AsNoTracking().Where(expression);
            var employeeResult = employees.Select(a => new Employee
            {
                Id = a.Id,
                Address = a.Address,
                BasicSalary = a.BasicSalary,
                Department = new Department
                {
                    Id = a.Department.Id,
                    Name = a.Department.Name
                },
                DepartmentId = a.DepartmentId,
                DOB = a.DOB,
                FirstName = a.FirstName,
                Gender = a.Gender,
                LastName = a.LastName
            });
            return employeeResult;
        }

        /// <summary>
        /// Find Employee by Id in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> FindAsync(Guid key)
        {
            var employee = await this.context.Employees.Include(i => i.Department).AsNoTracking().FirstOrDefaultAsync(e => e.Id == key);
            if (employee == null)
            {
                return default;
            }

            var employeeResult = new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Address = employee.Address,
                BasicSalary = employee.BasicSalary,
                DepartmentId = employee.DepartmentId,
                Department = new Department
                {
                    Id = employee.Department.Id,
                    Name = employee.Department.Name
                },
                DOB = employee.DOB,
            };
            return employeeResult;
        }

        /// <summary>
        /// Create Employee to the database
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> CreateAsync(Employee entity)
        {
            entity.Department = null;
            var result = await this.context.Employees.AddAsync(entity);
            var status = await this.context.SaveChangesAsync();
            return status > 0 ? result.Entity : default;
        }

        /// <summary>
        /// Update Employee in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> UpdateAsync(Employee entity)
        {
            var Employee = this.context.Employees.FirstOrDefault(x => x.Id == entity.Id);
            Employee.FirstName = entity.FirstName;
            Employee.LastName = entity.LastName;
            Employee.Gender = entity.Gender;
            Employee.DOB = entity.DOB;
            Employee.Address = entity.Address;
            Employee.DepartmentId = entity.DepartmentId;
            Employee.BasicSalary = entity.BasicSalary;
            Employee.Department = null;
            var result = this.context.Employees.Update(Employee);
            var status = await this.context.SaveChangesAsync();
            return status > 0 ? result.Entity : default;
        }

        /// <summary>
        /// Delete Employee in the database
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Employee entity)
        {
            var employee = this.context.Employees.FirstOrDefault(x => x.Id == entity.Id);
            this.context.Employees.Remove(employee);
            var status = await this.context.SaveChangesAsync();
            return status > 0;
        }
    }
}