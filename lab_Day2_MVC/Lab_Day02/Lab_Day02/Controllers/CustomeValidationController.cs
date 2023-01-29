using Lab_Day02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_Day02.Controllers
{
    public class CustomeValidationController : Controller
    {
        MVC_DbContext Db;
        public CustomeValidationController()
        {
            Db = new MVC_DbContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult validLocations(string ProjectLocation)
        {
            if (ProjectLocation == "cairo" || ProjectLocation == "giza" || ProjectLocation == "alex")
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }







    }
}
