using Microsoft.AspNetCore.Mvc;

namespace BuggyBits.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}