using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            if (Helper.loggedInUser == null)
            return View("Views/Welcome/Index.cshtml");

            ViewBag.user = Helper.loggedInUser;
            return View();
        }
    }
}
