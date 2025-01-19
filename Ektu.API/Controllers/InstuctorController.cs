using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Ektu.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InstuctorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstuctorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> InstructorApproved(int instructorId)
        {
            var response = await _instructorRepository.InstructorSelectedCourse(instructorId);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> LoginInstructor(LoginInstructorRequestDto loginInstructorRequestDto)
        {
            var response = await _instructorRepository.LoginInstructor(loginInstructorRequestDto.Email, loginInstructorRequestDto.Password);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> InstructorInfo(int instructorId)
        {
            return Ok(await _instructorRepository.InstructorInfo(instructorId));
        }
        [HttpGet]
        public async Task<IActionResult> InstructorGetCourse(int instructorId)
        {
            return Ok(await _instructorRepository.InstructorGetCourse(instructorId));
        }
        [HttpPost]
        public async Task<IActionResult> RefreshEmail(int instructorId, string newEmail)
        {
            return Ok(await _instructorRepository.RefreshEmail(instructorId, newEmail));
        }
        [HttpPost]
        public async Task<IActionResult> RefreshPassword(int instructorId, string newPassword)
        {
            return Ok(await _instructorRepository.RefreshPassword(instructorId, newPassword));
        }
        [HttpGet]
        public async Task<IActionResult> InstructorApp(int instructorId)
        {
            return Ok(await _instructorRepository.InstructorApproved(instructorId));
        }
    }
}
