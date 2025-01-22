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
                if (response.IsSuccess)
                {
                    TempData["userId"] = response.Data.Id;
                    TempData["userName"] = response.Data.FullName;

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
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> StudentCourse(int userId)
        {
            TempData["userId"] = userId;
            var data = await _studentApiService.StudentCourseApi(userId);
            var dataProfileInfo = await _studentApiService.ProfileApi(userId);
            TempData["userName"] = dataProfileInfo.FirstName + " " + dataProfileInfo.LastName;
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Profile(int userId)
        {
            TempData["userId"] = userId;
            var data = await _studentApiService.ProfileApi(userId);
            TempData["userName"] = data.FirstName + " " + data.LastName;
            return View(data);
        }
    }
}
