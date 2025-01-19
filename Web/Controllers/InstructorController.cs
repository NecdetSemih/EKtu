using EKtu.WEB.Models;
using EKtu.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EKtu.WEB.Controllers
{
    public class InstructorController : Controller
    {
        private readonly InstructorApiService _instructorApiService;
        public InstructorController(InstructorApiService instructorApiService)
        {
            _instructorApiService = instructorApiService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(InstructorLoginViewModel instructorLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _instructorApiService.InstructorLogin(instructorLoginViewModel);
                if (response)
                {

                }
                else
                {
                    ViewData["Hata"] = "Email veya Şifre hatalı";
                }
            }
            return View();
        }
    }
}
