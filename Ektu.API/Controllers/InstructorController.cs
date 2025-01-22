using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Ektu.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpGet]
        public async Task<IActionResult> InstructorApproved(int instructorId)
        {
            var response = await _instructorService.InstructorSelectedCourse(instructorId);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> LoginInstructor(LoginInstructorRequestDto loginInstructorRequestDto)
        {
            var response = await _instructorService.LoginInstructor(loginInstructorRequestDto.Email, loginInstructorRequestDto.Password);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> InstructorInfo(int instructorId)
        {
            return Ok(await _instructorService.InstructorInfo(instructorId));
        }
        [HttpGet]
        public async Task<IActionResult> InstructorGetCourse(int instructorId)
        {
            return Ok(await _instructorService.InstructorGetCourse(instructorId));
        }
        [HttpPost]
        public async Task<IActionResult> RefreshEmail(int instructorId, string newEmail)
        {
            return Ok(await _instructorService.RefreshEmail(instructorId, newEmail));
        }
        [HttpPost]
        public async Task<IActionResult> RefreshPassword(int instructorId, string newPassword)
        {
            return Ok(await _instructorService.RefreshPassword(instructorId, newPassword));
        }
        [HttpGet]
        public async Task<IActionResult> InstructorApp(int instructorId)
        {
            return Ok(await _instructorService.InstructorApproved(instructorId));
        }
        [HttpGet]
        public async Task<IActionResult> SelectedStudentApproved(int userId)
        {
            return Ok(await _instructorService.SelectedUserApproved(userId));
        }
        [HttpPost]
        public async Task<IActionResult> GetAllSelectedStudentApproved([FromBody] List<int> UserIds)
        {
            return Ok(await _instructorService.GetAllSelectedUserApproved(UserIds));
        }
        [HttpPost]
        public async Task<IActionResult> GetAllSelectedStudentReject([FromBody] List<int> UserIds)
        {
            return Ok(await _instructorService.GetSelectedUserReject(UserIds));
        }
        [HttpGet]
        public async Task<IActionResult> SelectedStudentReject(int userId)
        {
            return Ok(await _instructorService.SelectedStudentReject(userId));
        }
    }
}
