namespace EKtu.Application.Dtos
{
    public class StudentRefreshEmailRequestDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
