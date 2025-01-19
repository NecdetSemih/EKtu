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
            await _instructorRepository.InstructorSelectedCourseApproved(instructorId);

            return Ok();
        }
    }
}
