namespace ExamProject.Entities
{
    public class CourseEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Guid TeacherId { get; set; }
        public virtual ICollection<StudentCourseEntity> StudentCourses { get; set; }
        public virtual TeacherEntity Teacher { get; set; }
    }
}
