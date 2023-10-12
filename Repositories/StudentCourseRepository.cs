using ExamProject.Entities;
using ExamProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using School_System.Repositories;

namespace ExamProject.Repositories
{
    public class StudentCourseRepository: GenericRepository<StudentCourseEntity>, IStudentCourseRepository 
    {
        private readonly MainDBContext _context;
        public StudentCourseRepository(MainDBContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<StudentCourseEntity> GetByStudentIdAndCourseName(Guid studentId, Guid courseId)
        {
            var data = await _context.Set<StudentCourseEntity>()
                .Where(x => x.StudentId == studentId && x.CourseId == courseId)
                .FirstOrDefaultAsync();
            return data;

        }
    }
}
