namespace ExamProject.Entities
{
    public class StudentCourseEntity :BaseEntity
    {
        public Guid StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }
        public Guid CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
    }
}
