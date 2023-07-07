using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AvailableCoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
