using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Web.Controllers
{
    public class AdminController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public AdminController( UserManager<IdentityUser> userManager)
        {
           
          
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> AdminProfile()
        {

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            bool IsAdmin = currentUser.IsInRole("Admin");
            var id = _userManager.GetUserId(User); // Get user id:

            var user = await _userManager.FindByIdAsync(id);

            var adminProfileViewModel = new AdminProfileViewModel();
            adminProfileViewModel.Name = user.UserName;
            adminProfileViewModel.AdminUserId = user.Id;
            adminProfileViewModel.Email = user.Email;
            adminProfileViewModel.PhoneNumber = user.PhoneNumber;
            return View(adminProfileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdminProfile(AdminProfileViewModel adminProfileViewModel)
        {
            var adminUser = await _userManager.FindByIdAsync(adminProfileViewModel.AdminUserId);
            adminUser.UserName = adminProfileViewModel.Name;
            adminUser.Email = adminProfileViewModel.Email;
            adminUser.PhoneNumber = adminProfileViewModel.PhoneNumber;
           await  _userManager.UpdateAsync(adminUser);
            adminProfileViewModel.Name = adminUser.UserName;
            adminProfileViewModel.Email = adminUser.Email;
            adminProfileViewModel.PhoneNumber = adminUser.PhoneNumber;
            return View(adminProfileViewModel);
        }
    }


   
}
