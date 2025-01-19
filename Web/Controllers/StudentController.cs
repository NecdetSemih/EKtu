using EKtu.WEB.Models;
using EKtu.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EKtu.WEB.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentApiService _studentApiService;
        public StudentController(StudentApiService studentApiService)
        {
            _studentApiService = studentApiService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(StudentLoginViewModel studentLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _studentApiService.StudentLoginApi(studentLoginViewModel);
                if (response is not null)
                {
                    TempData["userId"] = response.Id;
                    TempData["userName"] = response.FullName;

                    return RedirectToAction(nameof(StudentChooseCourse));
                }
                else
                {
                    ViewData["Hata"] = "Email veya Şifre hatalı";
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> StudentChooseCourse()
        {
            var data = await _studentApiService.GetAllCourseApi();
            TempData["userId"] = TempData["userId"];
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> StudentCourse(int userId)
        {
            var data = await _studentApiService.StudentCourseApi(userId);
            return View(data);
        }
    }
}
