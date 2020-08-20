using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.data_access.Models;
using app.services.Interfaces;
using app.services.Services;
using app.services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRetrieveService _service;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUserRetrieveService service)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _service = service;
        }

        [Route("getUser")]
        [HttpGet]
        public Task<ApplicationUser> GetUserById([FromRoute]string id)
        {
            return _service.GetUserAsync(id);
        }

        [Route("getUsers")]
        [HttpGet]
        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await _service.GetUsersAsync();
        }

        [Route("createAdminAccount")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
            {
                return BadRequest("User already exists!");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest("User creation failed! Please check user details and try again.");
            }

            if (!await _roleManager.RoleExistsAsync("admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await _roleManager.RoleExistsAsync("admin"))
            {
                await _userManager.AddToRoleAsync(user, "admin");
            }

            return Ok("User created successfully!");
        }
    }

    public class ApplicationUserViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
