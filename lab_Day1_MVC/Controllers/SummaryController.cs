using lab_Day1_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_Day1_MVC.Controllers
{
    public class SummaryController : Controller
    {
        public IActionResult Index()
        {
            return View("Summary",GuestData.getAll());
        }
    }
}
