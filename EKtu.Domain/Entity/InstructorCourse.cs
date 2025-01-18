namespace EKtu.Domain.Entity
{
    public class InstructorCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
}
