using lab_Day1_MVC.Models;
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


        public IActionResult Registration()
        {
            return View("Registration");
        }



        public IActionResult Summary()
        {
            return View("Summary", GuestData.getAll());
        }



        public IActionResult Thanks(Guest guest)
        {
            if (guest.willAttend == "True")
            {
                GuestData.AddGuest(guest);
                return View("Thanks", guest);
            }
            else return View("NotCome", guest);
        }






    }
}
