namespace EKtu.Application.Dtos
{
    public class StudentRefreshPasswordRequestDto
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string UpdatePassword { get; set; }
    }
}
