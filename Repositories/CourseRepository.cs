using ExamProject.Entities;
using ExamProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using School_System.Repositories;

namespace ExamProject.Repositories
{
    public class CourseRepository : GenericRepository<CourseEntity>, ICourseRepository
    {
        private readonly MainDBContext _context;
        public CourseRepository(MainDBContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<CourseEntity> GetCourseByName(string name)
        {
            var data = await _context.Set<CourseEntity>()
                    .Where(x => x.Name == name)
                    .FirstOrDefaultAsync();
            return data;
        }
        public override IQueryable<CourseEntity> GetAll()
        {
            var result = _context.Set<CourseEntity>()
             .Include(x => x.Teacher);
            return result;
        }
    }
}
