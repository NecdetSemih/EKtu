using EKtu.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EKtu.WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

    }
}
