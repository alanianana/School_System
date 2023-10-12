using ExamProject.Entities;
using School_System.Interfaces;

namespace ExamProject.Interfaces
{
    public interface ICourseRepository: IGenericRepository<CourseEntity>
    {
        Task<CourseEntity> GetCourseByName(string name);
        IQueryable<CourseEntity> GetAll();
    }
}
