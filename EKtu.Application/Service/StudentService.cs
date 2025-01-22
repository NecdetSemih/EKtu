using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using EKtu.Application.IService;
using EKtu.Domain.Entity;

namespace EKtu.Application.Service
{
    public class StudentService : IService.IStudentService
    {
        private readonly IRepository.IStudentService _studentRepository;
        public StudentService(IRepository.IStudentService studentRepository)
        {

        }
        public async Task AddAsync(Student entity)
        {
            if (string.IsNullOrWhiteSpace(entity.FirstName))
                return;

            await _studentRepository.AddAsync(entity);
        }

        public async Task<List<GetStudentCourseResponseDto>> GetListStudentChooseCourse(int userId)
        {
            if (userId == 0)
                return Enumerable.Empty<GetStudentCourseResponseDto>().ToList();

            return await _studentRepository.GetListStudentChooseCourse(userId);

        }

        public async Task<bool> RefreshEmail(StudentRefreshEmailRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) && string.IsNullOrWhiteSpace(dto.Password))
                return false;

            return await _studentRepository.RefreshEmail(dto);
        }

        public async Task<bool> RefreshPassword(StudentRefreshPasswordRequestDto studentRefreshPasswordRequestDto)
        {
            return await _studentRepository.RefreshPassword(studentRefreshPasswordRequestDto);
        }

        public async Task RemoveAsync(Student entity)
        {
            await _studentRepository.RemoveAsync(entity);
        }

        public async Task StudentChooseCourse(int studentId, List<int> courseIds)
        {
            await _studentRepository.StudentChooseCourse(studentId, courseIds);
        }

        public async Task<StudentInfoResponseDto> StudentInfo(int studentId)
        {
            return await _studentRepository.StudentInfo(studentId);
        }

        public async Task<ResponseDto<StudentLoginResponseDto>> StudentLogin(StudentLoginDto studentLoginDto)
        {
            return await _studentRepository.StudentLogin(studentLoginDto);
        }
    }
}
