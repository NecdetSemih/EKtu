using EKtu.Domain.Common;

namespace EKtu.Domain.Entity
{
    public class InstructorCourse:BaseEntity
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
}
