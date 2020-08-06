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

        public async Task<IEnumerable<Image>> GetImagesAsync(int start, int end, Categories category)
        {
            return
                (await _dbContext
                .Images
                .Where(img => category == Categories.All ? true : img.Category == category)
                .Skip(start)
                .Take(end - start)
                .ToListAsync())
                .Select(img =>
                {
                    img.Path = Constants.Constants.HostUrl + '/' + img.Path;
                    return img;
                });
        }

        public async Task<IEnumerable<Image>> GetImagesByCategoryAsync(Categories category, int start, int end)
        {
            return
                await _dbContext
                .Images
                .Where(img => img.Category == category)
                .Skip(start)
                .Take(end - start)
                .ToListAsync();
        }

        public async Task<IEnumerable<Image>> GetImagesByDateAsync(DateTime date, int start, int end)
        {
            return
                await _dbContext
                .Images
                .Where(img =>
                img.UploadDate.Year == date.Year &&
                img.UploadDate.Month == date.Month &&
                img.UploadDate.Day == date.Day)
                .Skip(start)
                .Take(end - start)
                .ToListAsync();
        }

        public async Task<IEnumerable<Image>> GetImagesByUserAsync(string userId, int start, int end)
        {
            return
                await _dbContext
                .Images
                .Where(img => img.UserId == userId)
                .Skip(start)
                .Take(end - start)
                .ToListAsync();
        }
    }
}
