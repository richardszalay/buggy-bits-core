using BuggyBits.Models;
using BuggyBits.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BuggyBits.Controllers
{
    public class FeaturedProductsController : Controller
    {
        private readonly DataLayer dataLayer;

        public FeaturedProductsController(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        public IActionResult Index()
        {
            System.DateTime start = System.DateTime.Now;
            //Thread.Sleep(3000);

            var model = new FeaturedProductsViewModel
            {
                FeaturedProducts = new DataView(dataLayer.GetFeaturedProducts()),
            };

            System.DateTime end = System.DateTime.Now;
            ViewData["StartTime"] = start.ToLongTimeString();
            ViewData["ExecutionTime"] = end.Subtract(start).Seconds + "." + end.Subtract(start).Milliseconds;

            return View(model);
        }
    }
}