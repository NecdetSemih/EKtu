using EKtu.Application.Dtos;
using EKtu.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKtu.Application.IService
{
    public interface IStudentService
    {
        Task AddAsync(Student entity);
        Task RemoveAsync(Student entity);
        Task<List<GetStudentCourseResponseDto>> GetListStudentChooseCourse(int userId);
        Task StudentChooseCourse(int studentId, List<int> courseIds);
        Task<bool> RefreshEmail(StudentRefreshEmailRequestDto dto);
        Task<bool> RefreshPassword(StudentRefreshPasswordRequestDto studentRefreshPasswordRequestDto);
        Task<StudentInfoResponseDto> StudentInfo(int studentId);
        Task<ResponseDto<StudentLoginResponseDto>> StudentLogin(StudentLoginDto studentLoginDto);

    }
}
