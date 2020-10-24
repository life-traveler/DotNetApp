using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;



        public AccountController(SignInManager<IdentityUser> signInManager, ILogger<LoginViewModel> logger,UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                var result = await _signInManager.PasswordSignInAsync(user.UserName, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if(roles[0] == "Administrator" )
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    
                }
            }

            
            return View();
        }



        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {

                var user = new IdentityUser { UserName = registerViewModel.Email, Email = registerViewModel.Email };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    // Assign the user to the 'RegisteredUser' role.
                    await _userManager.AddToRoleAsync(user, "RegisteredUser");

                    // Remove Lockout and E-Mail confirmation
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = false;

                    // persist the changes into the Database.
                    //DbContext.SaveChanges();
                    return RedirectToAction("Index", "Home");

                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid registration attempt.");

                }
            }

            return View();
        }




    }
}
