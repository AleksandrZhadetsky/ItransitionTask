using app.data_access.Data;
using app.data_access.Models;
using app.services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace app.services.Services
{
    public class UploadService : IUploadService
    {
        private ApplicationDbContext _dbContext;

        public UploadService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HandleFileUploadAsync(UploadRequest request, string pathToUploadFolder)
        {
            var userId = (await _dbContext.Users.Where(u => u.UserName == request.UserName).FirstOrDefaultAsync()).Id;
            var imageCategory = request.Category;
            var dbImage = new Image { Path = pathToUploadFolder, UserId = userId, UploadDate = DateTime.Now, Category = imageCategory };
            _dbContext.Images.Add(dbImage);
            await _dbContext.SaveChangesAsync();
        }
    }
}
