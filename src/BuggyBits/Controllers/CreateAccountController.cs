using Microsoft.AspNetCore.Mvc;
using System.Data;
using BuggyBits.ViewModels;
using BuggyBits.Models;

namespace BuggyBits.Controllers
{
    public class CreateAccountController : Controller
    {
        private readonly DataLayer dataLayer;

        public CreateAccountController(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateAccountViewModel model)
        {
            DataSet dsUsers = this.dataLayer.GetAllUsers();
            DataRow[] rows = dsUsers.Tables[0].Select($"UserName = '{model.UserName}'");
            if (rows.Length <= 0)
            {
                ViewData["Result"] = $"Welcome {model.FirstName} {model.LastName}";
                //logic for adding the user would go here
            }
            else
            {
                ViewData["Result"] = $"Sorry, the username {model.UserName} is already taken";
            }

            return Index(model);
        }
    }
}