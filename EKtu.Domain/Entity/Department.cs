namespace EKtu.Domain.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<InstructorDepartment> InstructorDepartments { get; set; }

    }
}
