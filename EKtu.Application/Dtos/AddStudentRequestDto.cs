namespace EKtu.Application.Dtos
{
    public class AddStudentRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int InstructorId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
