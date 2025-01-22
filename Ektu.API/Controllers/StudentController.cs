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
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
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
            await _studentService.AddAsync(studentDto);
            return Ok(1);
        }
        [HttpPost]
        public async Task<IActionResult> StudentChooseCourse([FromBody] StudentChooseCourseRequestDto studentChooseCourseRequestDto)
        {
            await _studentService.StudentChooseCourse(studentChooseCourseRequestDto.StudentId, studentChooseCourseRequestDto.CourseIds);
            return Ok(true);
        }
        [HttpPost]
        public async Task<IActionResult> RefreshEmail(StudentRefreshEmailRequestDto studentRefreshEmailRequestDto)
        {
            return Ok(await _studentService.RefreshEmail(studentRefreshEmailRequestDto));
        }
        [HttpPost]
        public async Task<IActionResult> RefreshPassword(StudentRefreshPasswordRequestDto studentRefreshPasswordRequestDto)
        {
            return Ok(await _studentService.RefreshPassword(studentRefreshPasswordRequestDto));
        }
        [HttpGet]
        public async Task<IActionResult> StudentInfo([FromQuery] int studentId)
        {
            return Ok(await _studentService.StudentInfo(studentId));
        }
        [HttpPost]
        public async Task<IActionResult> StudentLogin([FromBody] StudentLoginDto studentLoginDto)
        {
            return Ok(await _studentService.StudentLogin(studentLoginDto));
        }
        [HttpGet]
        public async Task<IActionResult> StudentCourse(int studentId)
        {
            return Ok(await _studentService.GetListStudentChooseCourse(studentId));
        }

    }
}
