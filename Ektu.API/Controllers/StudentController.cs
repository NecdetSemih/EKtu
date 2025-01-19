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
        public async Task<IActionResult> StudentChooseCourse(int studentId, List<int> courseIds)
        {
            await _studentRepository.StudentChooseCourse(studentId, courseIds);
            return Ok(1);
        }
        [HttpPost]
        public async Task<IActionResult> RefreshEmail(int studentId, string newEmail)
        {
            return Ok(await _studentRepository.RefreshEmail(studentId, newEmail));
        }
        [HttpPost]
        public async Task<IActionResult> RefreshPassword(int studentId, string newPassword)
        {
            return Ok(await _studentRepository.RefreshPassword(studentId, newPassword));
        }

    }
}
