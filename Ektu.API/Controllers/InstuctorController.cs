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

    }
}
