using Microsoft.AspNetCore.Mvc;

namespace lab_Day1_MVC.Properties.Controllers
{
    public class HomeController : Controller
    {
        // ----Action---- and thats the default action
        public IActionResult Index()
        {
            return View("Index");

        }


    }
}
