namespace ExamProject.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        ICourseRepository CourseRepository { get; }
        IStudentCourseRepository StudentCourseRepository { get; }
    }
}
