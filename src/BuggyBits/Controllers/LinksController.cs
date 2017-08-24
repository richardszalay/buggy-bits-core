using BuggyBits.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BuggyBits.Controllers
{
    public class LinksController : Controller
    {
        public IActionResult Index()
        {
            var model = new LinksViewModel()
            {
                Links = LinkList.GetAllLinks()
            };

            return View(model);
        }
    }
}
