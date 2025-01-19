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
                if (response)
                    return RedirectToAction(nameof(StudentChooseCourse));

                ViewData["Hata"] = "Email veya Şifre hatalı";
            }
            return View();
        }
        [HttpGet]
        public IActionResult StudentChooseCourse()
        {
            return View();
        }
    }
}
