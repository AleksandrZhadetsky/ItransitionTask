using app.data_access.Models;
using app.services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IUserRetrieveService
    {
        Task CreateUserAsync(RegisterModel model);
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserAsync(string id);
        Task UpdateUserAsync(ApplicationUser updateModel);
        Task DeleteUserAsync(string id);
    }
}
