namespace Business
{
    using System.Linq.Expressions;
    using Data.Models;
    using Data.Repository;
    using Microsoft.Extensions.Logging;

    public class EmployeeService
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly ILogger<EmployeeService> logger;

        /// <summary>
        /// Employee Service - Handling the Employee Business Logics before accessing the Data Layer
        /// </summary>
        public EmployeeService(ILogger<EmployeeService> logger, EmployeeRepository employeeRepository)
        {
            this.logger = logger;
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Get all the Employees in the system
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetAll()
        {
            var employees = this.employeeRepository.GetAll();
            this.logger.LogInformation($"Employees found {employees} on {nameof(GetAll)} in {nameof(EmployeeService)}");
            return employees;
        }

        /// <summary>
        /// Get Employee matching to the Search Criteria
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetByCondition(Expression<Func<Employee, bool>> expression)
        {
            if (expression == null)
            {
                this.logger.LogWarning($"Invalid Employee Search Condition on {nameof(GetByCondition)} in {nameof(EmployeeService)}");
                return default;
            }

            var employees = this.employeeRepository.GetByCondition(expression);
            if (employees == default)
            {
                this.logger.LogWarning($"Employees for Condition : {expression} not found on {nameof(GetByCondition)} in {nameof(EmployeeService)}");
                return default;
            }

            this.logger.LogInformation($"Employees for Condition : {expression} found {employees} on {nameof(GetByCondition)} in {nameof(EmployeeService)}");
            return employees;
        }

        /// <summary>
        /// Find Employee by Id in the system
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> FindAsync(Guid key)
        {
            if (key == Guid.Empty)
            {
                this.logger.LogWarning($"Invalid Employee Id on {nameof(FindAsync)} in {nameof(EmployeeService)}");
                return default;
            }

            var employee = await this.employeeRepository.FindAsync(key);
            if (employee == default)
            {
                this.logger.LogWarning($"Employee for Id not found on {nameof(FindAsync)} in {nameof(EmployeeService)}");
                return default;
            }

            this.logger.LogInformation($"Employee for Id : {key} found {employee} on {nameof(FindAsync)} in {nameof(EmployeeService)}");
            return employee;
        }

        /// <summary>
        /// Create Employee to the system
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> CreateAsync(Employee entity)
        {
            this.logger.LogInformation($"Create Employee on {nameof(CreateAsync)} in {nameof(EmployeeService)} with Employee details : {entity}");
            var result = await this.employeeRepository.CreateAsync(entity);
            return result;
        }

        /// <summary>
        /// Update Employee in the system
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> UpdateAsync(Employee entity)
        {
            if (entity.Id == Guid.Empty)
            {
                this.logger.LogWarning($"Invalid Employee Id on {nameof(UpdateAsync)} in {nameof(EmployeeService)}");
                return default;
            }

            var employee = await this.FindAsync(entity.Id);
            if (employee == default)
            {
                this.logger.LogWarning($"Employee for Id : {entity.Id} not found on {nameof(UpdateAsync)} in {nameof(EmployeeService)}");
                return default;
            }

            this.logger.LogInformation($"Update Employee on {nameof(UpdateAsync)} in {nameof(EmployeeService)} with Employee details : {entity}");
            var result = await this.employeeRepository.UpdateAsync(entity);
            return result;
        }

        /// <summary>
        /// Delete Employee in the system
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Employee entity)
        {
            if (entity.Id == Guid.Empty)
            {
                this.logger.LogWarning($"Invalid Employee Id on {nameof(DeleteAsync)} in {nameof(EmployeeService)}");
                return default;
            }

            var employee = await this.FindAsync(entity.Id);
            if (employee == default)
            {
                this.logger.LogWarning($"Employee for Id : {entity.Id} not found on {nameof(DeleteAsync)} in {nameof(EmployeeService)}");
                return default;
            }

            this.logger.LogInformation($"Delete Employee on {nameof(DeleteAsync)} in {nameof(EmployeeService)} with Employee details : {entity}");
            var result = await this.employeeRepository.DeleteAsync(entity);
            return result;
        }
    }
}