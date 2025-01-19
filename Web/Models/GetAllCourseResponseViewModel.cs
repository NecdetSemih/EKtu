namespace Web.Models
{
    public class GetAllCourseResponseViewModel
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credit { get; set; }
        public bool Mandatory { get; set; }
        public string DepartmentName { get; set; }
    }
}
