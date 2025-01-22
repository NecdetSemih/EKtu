using EKtu.Application.IRepository;
using EKtu.Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace Ektu.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseRepository)
        {
            _courseService = courseRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            return Ok(await _courseService.GetAllCourse());
        }
    }
}
