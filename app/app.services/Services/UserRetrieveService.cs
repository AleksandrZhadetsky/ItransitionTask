using app.data_access.Models;
using app.services.Interfaces;
using app.services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.services.Services
{
    public class UserRetrieveService : IUserRetrieveService
    {
        private readonly IUserRetrieveSqlRepository _repository;

        public UserRetrieveService(IUserRetrieveSqlRepository repository)
        {
            _repository = repository;
        }

        public Task CreateUserAsync(RegisterModel model)
        {
            return _repository.CreateUserAsync(model);
        }

        public Task DeleteUserAsync(string id)
        {
            return _repository.DeleteUserAsync(id);
        }

        public Task<ApplicationUser> GetUserAsync(string id)
        {
            return _repository.GetUserAsync(id);
        }

        public Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            return _repository.GetUsersAsync();
        }

        public Task UpdateUserAsync(ApplicationUser updateModel)
        {
            return _repository.UpdateUserAsync(updateModel);
        }
    }
}
