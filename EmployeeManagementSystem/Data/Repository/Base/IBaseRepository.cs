namespace Data.Repository.Base
{
    using System.Linq.Expressions;

    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindAsync(Guid key);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}