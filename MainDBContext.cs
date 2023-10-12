using ExamProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamProject
{
    public class MainDBContext: DbContext
    {
        public MainDBContext(DbContextOptions<MainDBContext> options) : base(options) { }
        DbSet<StudentEntity> Students { get; set; }
        DbSet<CourseEntity> Courses { get; set; }
        DbSet<StudentCourseEntity> StudentCourses { get; set; }
        DbSet<TeacherEntity> Teachers { get; set; }
    }
}
