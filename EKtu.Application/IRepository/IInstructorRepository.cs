using EKtu.Application.Dtos;

namespace EKtu.Application.IRepository
{
    public interface IInstructorRepository
    {
        Task<ResponseDto<InstructorLoginResponseDto>> LoginInstructor(string email, string password);
        Task<List<InstructorApprovedDto>> InstructorSelectedCourse(int instructorId);
        Task<InstructorInfoResponseDto> InstructorInfo(int instructorId);
        Task<List<string>> InstructorGetCourse(int instructorId);
        Task<bool> RefreshEmail(int instructorId, string newEmail);
        Task<bool> RefreshPassword(int instructorId, string newPassword);
        Task<bool> InstructorApproved(int instructorId);
        Task<bool> SelectedUserApproved(int userId);
        Task<bool> GetAllSelectedUserApproved(List<int> instructorIds);
        Task<bool> GetSelectedUserReject(List<int> instructorIds);
        Task<bool> SelectedStudentReject(int userId);
    }
}
