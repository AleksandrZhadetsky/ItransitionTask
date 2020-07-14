using app.data_access.Data;
using app.data_access.Models;
using app.services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.services.Services
{
    public class ImageRetrieveService : IImageRetrieveService
    {
        private readonly ApplicationDbContext _dbContext;

        public ImageRetrieveService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> GetImageUrlsAsync()
        {
            return await _dbContext.Images.Select(img => img.Path).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetImageUrlsByCategoryAsync(Category category)
        {
            return category == (Category)Constants.Constants.InvalidCategory ? await GetImageUrlsAsync() : await _dbContext.Images.Where(img => img.Category == category).Select(img => img.Path).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetImageUrlsByDateAsync(DateTime date)
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

        public async Task<IEnumerable<string>> GetImageUrlsByUserAsync(string userId)
        {
            return await _dbContext
                .Images
                .Where(img => img.UserId == userId)
                .Select(img => img.Path)
                .ToListAsync();
        }
    }
}
