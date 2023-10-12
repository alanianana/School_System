using ExamProject.Entities;
using School_System.Interfaces;

namespace ExamProject.Interfaces
{
    public interface IStudentRepository: IGenericRepository<StudentEntity>
    {
        Task<StudentEntity> GetByIdNumber(int idNumber);
    }
}
