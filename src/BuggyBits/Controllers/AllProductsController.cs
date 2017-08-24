using Microsoft.AspNetCore.Mvc;
using BuggyBits.Models;
using System.Data;
using BuggyBits.ViewModels;
using Microsoft.AspNetCore.Html;

namespace BuggyBits.Controllers
{
    public class AllProductsController : Controller
    {
        private readonly DataLayer dataLayer;

        public AllProductsController(DataLayer dataLayer)
        {
            this.dataLayer = new DataLayer();
        }

        public IActionResult Index()
        {
            DataTable dt = this.dataLayer.GetAllProducts();
            string ProductsTable = "<table><tr><td><B>Product ID</B></td><td><B>Product Name</B></td><td><B>Description</B></td></tr>";

            foreach (DataRow dr in dt.Rows)
            {
                ProductsTable += "<tr><td>" + dr[0] + "</td><td>" + dr[1] + "</td><td>" + dr[2] + "</td></tr>";
            }
            ProductsTable += "</table>";

            var model = new AllProductsViewModel
            {
                ProductsTable = new HtmlString(ProductsTable)
            };

            return View(model);
        }
    }
}