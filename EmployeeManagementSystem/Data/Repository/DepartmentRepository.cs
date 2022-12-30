namespace Data.Repository
{
    using System.Linq.Expressions;
    using Data.Models;
    using Data.Repository.Base;

    public class DepartmentRepository : IBaseRepository<Department>
    {
        private readonly DataContext context;

        public DepartmentRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Department> FindAsync(Guid key)
        {
            var department = await this.context.Departments.FindAsync(key);
            return department;
        }

        public IQueryable<Department> GetAll()
        {
            var departments = this.context.Departments;
            return departments;
        }

        public IQueryable<Department> GetByCondition(Expression<Func<Department, bool>> expression)
        {
            var departments = this.context.Departments.Where(expression);
            return departments;
        }

        public async Task<Department> CreateAsync(Department entity)
        {
            var result = await this.context.Departments.AddAsync(entity);
            var status = await this.context.SaveChangesAsync();
            return status > 0 ? result.Entity : default;
        }

        public async Task<Department> UpdateAsync(Department entity)
        {
            var department = this.context.Departments.FirstOrDefault(x => x.Id == entity.Id);
            department.Name = entity.Name;
            var result = this.context.Departments.Update(department);
            var status = await this.context.SaveChangesAsync();
            return status > 0 ? result.Entity : default;
        }

        public async Task<bool> DeleteAsync(Department entity)
        {
            var department = this.context.Departments.FirstOrDefault(x => x.Id == entity.Id);
            this.context.Departments.Remove(department);
            var status = await this.context.SaveChangesAsync();
            return status > 0;
        }
    }
}
