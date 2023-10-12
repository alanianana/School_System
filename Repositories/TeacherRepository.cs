using ExamProject.Entities;
using ExamProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using School_System.Repositories;

namespace ExamProject.Repositories
{
    public class TeacherRepository: GenericRepository<TeacherEntity>, ITeacherRepository
    { 

        private readonly MainDBContext _context;
        public TeacherRepository(MainDBContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<TeacherEntity> GetTeacherByIdNUmber(int idNumber)
        {
            var data = await _context.Set<TeacherEntity>()
                    .Where(x => x.TeacherIdNumber == idNumber)
                    .FirstOrDefaultAsync();
            return data;
        }
        public override IQueryable<TeacherEntity> GetAll()
        {
            var result = _context.Set<TeacherEntity>()
             .Include(x => x.Course);
            return result;
        }

    }
}
