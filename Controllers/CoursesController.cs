using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View(); //cerca una view dentro la cartella View/Courses
        }

        public IActionResult Detail(string id)
        {
            return View();
        }
    }
}