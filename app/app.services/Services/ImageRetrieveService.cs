using app.data_access.Data;
using app.data_access.Models;
using app.services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.services.Services
{
    public class ImageRetrieveService : IImageRetrieveService
    {
        private ApplicationDbContext _dbContext;

        public async Task<IList<string>> GetImageUrlsAsync()
        {
            return await _dbContext.Images.Select(img => img.Path).ToListAsync();
        }

        public async Task<IList<string>> GetImageUrlsByCategoryAsync(Category category)
        {
            return category == 0 ? await GetImageUrlsAsync() : await _dbContext.Images.Where(img => img.Category == category).Select(img => img.Path).ToListAsync();
        }

        public async Task<IList<string>> GetImageUrlsByDateAsync(DateTime date)
        {
            return 
                await _dbContext
                .Images
                .Where(img =>
                img.UploadDate.Year == date.Year &&
                img.UploadDate.Month == date.Month &&
                img.UploadDate.Day == date.Day)
                .Select(img => img.Path)
                .ToListAsync();
        }

        public async Task<IList<string>> GetImageUrlsByUserAsync(string userId)
        {
            return await _dbContext
                .Images
                .Where(img => img.UserId == userId)
                .Select(img => img.Path)
                .ToListAsync();
        }
    }
}
