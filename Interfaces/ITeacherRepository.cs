using ExamProject.Entities;
using School_System.Interfaces;

namespace ExamProject.Interfaces
{
    public interface ITeacherRepository: IGenericRepository<TeacherEntity>
    {
        Task<TeacherEntity> GetTeacherByIdNUmber(int idNumber);
         IQueryable<TeacherEntity> GetAll();
    }
}
