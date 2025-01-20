using EKtu.Application.Dtos;
using EKtu.Domain.Entity;

namespace EKtu.Application.IRepository
{
    public interface IStudentRepository
    {
        Task AddAsync(Student entity);
        Task RemoveAsync(Student entity);
        Task<List<GetStudentCourseResponseDto>> GetListStudentChooseCourse(int userId);
        Task StudentChooseCourse(int studentId, List<int> courseIds);
        Task<bool> RefreshEmail(StudentRefreshEmailRequestDto dto);
        Task<bool> RefreshPassword(int studentId, string newPassword);
        Task<StudentInfoResponseDto> StudentInfo(int studentId);
        Task<StudentLoginResponseDto> StudentLogin(StudentLoginDto studentLoginDto);
    }
}
