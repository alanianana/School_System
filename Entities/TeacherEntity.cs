namespace ExamProject.Entities
{
    public class TeacherEntity:BaseEntity
    {
        public int TeacherIdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Experience { get; set; }
        public virtual ICollection< CourseEntity> Course { get; set; }

    }
}
