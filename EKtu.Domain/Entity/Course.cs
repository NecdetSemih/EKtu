using EKtu.Domain.Common;

namespace EKtu.Domain.Entity
{
    public class Course: BaseEntity
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Quota { get; set; }
        public int Credit { get; set; }
        public bool Mandatory { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<InstructorCourse> InstructorCourses { get; set; }
        public ICollection<StudentChooseCourse> StudentChooseCourses { get; set; }
    }
}
