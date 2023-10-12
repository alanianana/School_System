using ExamProject.Entities;
using ExamProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using School_System.Repositories;

namespace ExamProject.Repositories
{
    public class StudentRepository: GenericRepository<StudentEntity>, IStudentRepository
    {
        private readonly MainDBContext _context;
        public StudentRepository(MainDBContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<StudentEntity> GetByIdNumber(int idNumber)
        {
            var data = await _context.Set<StudentEntity>()
                    .Where(x => x.StudnetIdNumber == idNumber)
                    .FirstOrDefaultAsync();
            return data;
        }
    }
}
