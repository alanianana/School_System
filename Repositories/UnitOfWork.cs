using ExamProject.Interfaces;
using ExamProject.Interfaces;

namespace School_System.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
        }

        public IStudentRepository StudentRepository =>
            _serviceProvider.GetRequiredService<IStudentRepository>();

        public ITeacherRepository TeacherRepository =>
            _serviceProvider.GetRequiredService<ITeacherRepository>();

        public ICourseRepository CourseRepository =>
            _serviceProvider.GetRequiredService<ICourseRepository>();

        public IStudentCourseRepository StudentCourseRepository =>
            _serviceProvider.GetRequiredService<IStudentCourseRepository>();
    }
}
