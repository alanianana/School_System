using ExamProject.Entities;
using School_System.Interfaces;

namespace ExamProject.Interfaces
{
    public interface IStudentCourseRepository: IGenericRepository<StudentCourseEntity>
    {
        Task<StudentCourseEntity> GetByStudentIdAndCourseName(Guid studentId, Guid courseId);

    }
}
