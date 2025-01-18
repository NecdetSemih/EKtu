using EKtu.Domain.Common;

namespace EKtu.Domain.Entity
{
    public class Department: BaseEntity
    {
        public string DepartmentName { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<InstructorDepartment> InstructorDepartments { get; set; }

    }
}
