namespace Business
{
    using System.Linq.Expressions;
    using Data.Models;
    using Data.Repository;
    using Microsoft.Extensions.Logging;

    public class DepartmentService
    {
        private readonly DepartmentRepository departmentRepository;
        private readonly ILogger<DepartmentService> logger;

        public DepartmentService(ILogger<DepartmentService> logger, DepartmentRepository departmentRepository)
        {
            this.logger = logger;
            this.departmentRepository = departmentRepository;
        }

        public async Task<Department> FindAsync(Guid key)
        {
            if (key == Guid.Empty)
            {
                this.logger.LogWarning($"Invalid Department Id on {nameof(FindAsync)} in {nameof(DepartmentService)}");
                return default;
            }

            var department = await this.departmentRepository.FindAsync(key);
            if (department == default)
            {
                this.logger.LogWarning($"Department for Id not found on {nameof(FindAsync)} in {nameof(DepartmentService)}");
                return default;
            }

            this.logger.LogInformation($"Department for Id : {key} found {department} on {nameof(FindAsync)} in {nameof(DepartmentService)}");
            return department;
        }

        public IQueryable<Department> GetAll()
        {
            var departments = this.departmentRepository.GetAll();
            this.logger.LogInformation($"Departments found {departments} on {nameof(GetAll)} in {nameof(DepartmentService)}");
            return departments;
        }

        public IQueryable<Department> GetByCondition(Expression<Func<Department, bool>> expression)
        {
            if (expression == null)
            {
                this.logger.LogWarning($"Invalid Department Search Condition on {nameof(GetByCondition)} in {nameof(DepartmentService)}");
                return default;
            }

            var departments = this.departmentRepository.GetByCondition(expression);
            if (departments == default)
            {
                this.logger.LogWarning($"Departments for Condition : {expression} not found on {nameof(GetByCondition)} in {nameof(DepartmentService)}");
                return default;
            }

            this.logger.LogInformation($"Departments for Condition : {expression} found {departments} on {nameof(GetByCondition)} in {nameof(DepartmentService)}");
            return departments;
        }

        public async Task<Department> CreateAsync(Department entity)
        {
            this.logger.LogInformation($"Create Department on {nameof(CreateAsync)} in {nameof(DepartmentService)} with Department details : {entity}");
            var result = await this.departmentRepository.CreateAsync(entity);
            return result;
        }

        public async Task<Department> UpdateAsync(Department entity)
        {
            if (entity.Id == Guid.Empty)
            {
                this.logger.LogWarning($"Invalid Department Id on {nameof(UpdateAsync)} in {nameof(DepartmentService)}");
                return default;
            }

            var department = this.FindAsync(entity.Id);
            if (department == default)
            {
                this.logger.LogWarning($"Department for Id : {entity.Id} not found on {nameof(UpdateAsync)} in {nameof(DepartmentService)}");
                return default;
            }

            this.logger.LogInformation($"Update Department on {nameof(UpdateAsync)} in {nameof(DepartmentService)} with Department details : {entity}");
            var result = await this.departmentRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<bool> DeleteAsync(Department entity)
        {
            if (entity.Id == Guid.Empty)
            {
                this.logger.LogWarning($"Invalid Department Id on {nameof(DeleteAsync)} in {nameof(DepartmentService)}");
                return default;
            }

            var department = this.FindAsync(entity.Id);
            if (department == default)
            {
                this.logger.LogWarning($"Department for Id : {entity.Id} not found on {nameof(DeleteAsync)} in {nameof(DepartmentService)}");
                return default;
            }

            this.logger.LogInformation($"Delete Department on {nameof(DeleteAsync)} in {nameof(DepartmentService)} with Department details : {entity}");
            var result = await this.departmentRepository.DeleteAsync(entity);
            return result;
        }
    }
}