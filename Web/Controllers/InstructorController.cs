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
                if (response.IsSuccess)
                {
                    TempData["userId"] = response.Data.Id;
                    TempData["userName"] = response.Data.FirstName;
                    return RedirectToAction("Approved", new { userId = response.Data.Id });
                }
                else
                {
                    ViewData["Hata"] = "Email veya Şifre hatalı";
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Approved(int userId)
        {
            var data = await _instructorApiService.InstructorInfo(userId);
            TempData["userName"] = data.FirstName + " " + data.LastName;
            var response = await _instructorApiService.InstructorApprovedApi(Convert.ToInt16(userId));
            return View(response);
        }
    }
}
