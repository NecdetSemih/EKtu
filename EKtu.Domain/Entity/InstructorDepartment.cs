using EKtu.Domain.Common;

namespace EKtu.Domain.Entity
{
    public class InstructorDepartment:BaseEntity
    {

        public int InstructorId { get; set; }
        public int DepartmentId { get; set; }
        public Instructor Instructor { get; set; }
        public Department Deparment { get; set; }
    }
}
