namespace ExamProject.Entities
{
    public class StudentEntity :BaseEntity
    {
        public int StudnetIdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Age { get; set; }
        public virtual ICollection<StudentCourseEntity> StudentCourse { get;}

    }
}
