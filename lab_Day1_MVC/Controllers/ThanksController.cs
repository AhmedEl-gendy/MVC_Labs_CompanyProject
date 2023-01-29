using lab_Day1_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_Day1_MVC.Controllers
{
    public class ThanksController : Controller
    {
        public IActionResult Index(Guest guest)
        {
            if (guest.willAttend == "True")
            {
                GuestData.AddGuest(guest);
                return View("Thanks", guest);
            }
            else return View("NotCome",guest);
        }
    }
}
