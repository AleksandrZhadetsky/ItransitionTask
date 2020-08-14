using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using app.data_access.Data;
using app.data_access.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Authorize]
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("createAdminAccount")]
        [HttpPost]
        public async Task<IActionResult> CreateAdminAccount([FromBody]ApplicationUserViewModel model)
        {
            ApplicationUser _user = new ApplicationUser { Email = model.Email, UserName = model.Email };
            // добавляем пользователя
            var result = await _userManager.CreateAsync(_user, model.Password);
            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(_user, false);
                var createdUser = _userManager.Users.First(user => user.Email == model.Email);
                await _userManager.AddClaimAsync(createdUser, new Claim("ApplicationRole", "Admin"));
                return Ok(createdUser);
            }

            return Ok("failed to sign in");
        }
    }

    public class ApplicationUserViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
