using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace School_System.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task<T?> GetById(Guid Id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
