using app.data_access.Models;
using app.services.Interfaces;
using app.services.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.services.Repositories
{
    public class UserRetrieveSqlRepository : IUserRetrieveSqlRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRetrieveSqlRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task CreateUserAsync(RegisterModel model)
        {
            var userExists = await _userManager.Users.Where(user => user.UserName == model.UserName).AnyAsync();

            if (userExists)
            {
                throw new Exception("User already exists!");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User creation failed! Please check user details and try again.");
            }
        }

        public Task DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserAsync(string id)
        {
            return await _userManager.Users.Where(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public Task UpdateUserAsync(ApplicationUser updateModel)
        {
            throw new NotImplementedException();
        }
    }
}
