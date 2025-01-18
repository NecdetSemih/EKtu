namespace EKtu.Domain.Entity
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TitleId { get; set; }
        public Title Title { get; set; }
        public ICollection<InstructorCourse> InstructorCourses { get; set; }
        public ICollection<InstructorDepartment> InstructorDepartments { get; set; }

    }
}
