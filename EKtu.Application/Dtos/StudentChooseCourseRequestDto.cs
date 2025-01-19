namespace EKtu.Application.Dtos
{
    public class StudentChooseCourseRequestDto
    {
        public int StudentId { get; set; }
        public List<int> CourseIds { get; set; }
    }
}
