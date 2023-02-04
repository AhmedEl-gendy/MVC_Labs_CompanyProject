using Lab_Day02.Models;
using Lab_Day02.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Lab_Day02.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            this.userManager = _userManager;
            this.roleManager = _roleManager;
        }

        public IActionResult Index()
        {
            List<ApplicationUser> users = userManager.Users.ToList();
            List<RegistrationVM> usersDisplay = new List<RegistrationVM>();
            foreach (var item in users)
            {
                usersDisplay.Add(new RegistrationVM()
                {
                    UserName = item.UserName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    RegisterDate = item.RegisterDate,
                    Address = item.Address,
                    Age = item.Age,
                });
            }
            return View(usersDisplay);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM registrationVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = registrationVM.UserName,
                    Email = registrationVM.Email,
                    PhoneNumber = registrationVM.PhoneNumber,
                    RegisterDate = registrationVM.RegisterDate,
                    Address = registrationVM.Address,
                    Age = registrationVM.Age,
                };
                IdentityResult result = await userManager.CreateAsync(user, registrationVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registrationVM);
            }
            return View(registrationVM);
        }


        









    }
}
