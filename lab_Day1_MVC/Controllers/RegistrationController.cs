using Microsoft.AspNetCore.Mvc;

namespace lab_Day1_MVC.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View("Registration");
        }
    }
}
