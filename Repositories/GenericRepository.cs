using ExamProject.Interfaces;
using ExamProject;
using Microsoft.EntityFrameworkCore;
using ExamProject.Entities;
using ExamProject.Interfaces;
using System.Linq.Expressions;
using School_System.Interfaces;

namespace School_System.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MainDBContext _context;

        public GenericRepository(MainDBContext context)
        {
            _context = context;
        }
        public virtual async Task<bool> Any(Expression<Func<T, bool>> predicate) => await _context.Set<T>().AnyAsync(predicate);
        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public virtual async Task<T?> GetById(Guid Id) => await _context.Set<T>().FindAsync(Id);
        public virtual IQueryable<T> GetAll() => _context.Set<T>();
        public virtual async Task Add(T entity)
        {
            if (entity == null) return;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task Update(T entity)
        {
            if (entity == null) return;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

        }
        public virtual async Task Delete(T entity)
        {
            if (entity == null) return;
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

        }
        

    }
}
