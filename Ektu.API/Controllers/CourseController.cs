using EKtu.Application.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Ektu.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            return Ok(await _courseRepository.GetAllCourse());
        }
    }
}
