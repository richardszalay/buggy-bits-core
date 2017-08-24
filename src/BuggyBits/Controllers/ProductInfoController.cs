using BuggyBits.Models;
using BuggyBits.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BuggyBits.Controllers
{
    public class ProductInfoController : Controller
    {
        public IActionResult Index()
        {
            var productName = Request.Query["ProductName"];
            DataLayer dl = new DataLayer();
            Product p = dl.GetProductInfo(productName);
            var distributor = p.shippingInfo.Distributor;
            var shippingInfo = p.shippingInfo.DaysToShip.ToString() + " days";

            var model = new ProductInfoViewModel
            {
                ProductName = productName,
                Distributor = distributor,
                ShippingInfo = shippingInfo
            };

            return View(model);
        }
    }
}
