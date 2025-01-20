using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using EKtu.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Ektu.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentRequestDto student)
        {
            Student studentDto = new()
            {
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                InstructorId = student.InstructorId,
                Password = student.Password,

            };
            await _studentRepository.AddAsync(studentDto);
            return Ok(1);
        }
        [HttpPost]
        public async Task<IActionResult> StudentChooseCourse([FromBody] StudentChooseCourseRequestDto studentChooseCourseRequestDto)
        {
            await _studentRepository.StudentChooseCourse(studentChooseCourseRequestDto.StudentId, studentChooseCourseRequestDto.CourseIds);
            return Ok(true);
        }
        [HttpPost]
        public async Task<IActionResult> RefreshEmail(StudentRefreshEmailRequestDto studentRefreshEmailRequestDto)
        {
            return Ok(await _studentRepository.RefreshEmail(studentRefreshEmailRequestDto));
        }
        [HttpPost]
        public async Task<IActionResult> RefreshPassword(int studentId, string newPassword)
        {
            return Ok(await _studentRepository.RefreshPassword(studentId, newPassword));
        }
        [HttpGet]
        public async Task<IActionResult> StudentInfo([FromQuery] int studentId)
        {
            return Ok(await _studentRepository.StudentInfo(studentId));
        }
        [HttpPost]
        public async Task<IActionResult> StudentLogin([FromBody] StudentLoginDto studentLoginDto)
        {
            return Ok(await _studentRepository.StudentLogin(studentLoginDto));
        }
        [HttpGet]
        public async Task<IActionResult> StudentCourse(int studentId)
        {
            return Ok(await _studentRepository.GetListStudentChooseCourse(studentId));
        }

    }
}
