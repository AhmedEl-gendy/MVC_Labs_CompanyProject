using Lab_Day02.Models;
using Lab_Day02.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;

namespace Lab_Day02.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.roleManager = _roleManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    bool valid = await userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (valid)
                    { 
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim("Address",user.Address),
                            new Claim("Age",user.Age.ToString())
                        };
                        await signInManager.SignInWithClaimsAsync(user, loginVM.RememberMe, claims);
                        return RedirectToAction("Index", "Account");
                    }
                }
                ModelState.AddModelError("", "Wrong email or password");
                return View(loginVM);
            }
            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddUserToRole()
        {
            RoleToUserVM userRole = new()
            {
                Users = new SelectList(userManager.Users.ToList(), "Id", nameof(ApplicationUser.UserName)),
                Roles = new SelectList(roleManager.Roles.ToList(), "Name", "Name")
            };
            return View(userRole);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(RoleToUserVM roleToUser)
        {
            ApplicationUser user = await userManager.FindByIdAsync(roleToUser.UserId);
            IdentityResult result = await userManager.AddToRoleAsync(user, roleToUser.RoleName);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            roleToUser.Users = new SelectList(userManager.Users, "Id", "UserName");
            roleToUser.Roles = new SelectList(roleManager.Roles, "Name", "Name");
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            string userName = User.Identity.Name;
            bool isInRole = User.IsInRole("Admin");
            string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            string Address = User.Claims.FirstOrDefault(c => c.Type == "Address").Value;
            string Age = User.Claims.FirstOrDefault(c => c.Type == "Age").Value;
            ApplicationUser user = await userManager.FindByIdAsync(id);
            return View(user);
        }






    }
}
