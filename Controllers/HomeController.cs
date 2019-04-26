using Microsoft.AspNetCore.Mvc;

namespace MyCourse
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }
    }
}