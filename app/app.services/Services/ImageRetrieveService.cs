using app.data_access.Data;
using app.data_access.Models;
using app.services.Interfaces;
using System;
using System.Linq;

namespace app.services.Services
{
    public class ImageRetrieveService : IImageRetrieveService
    {
        private readonly ApplicationDbContext _dbContext;

        public ImageRetrieveService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Image> GetImagesAsync(int start, int end)
        {
            return
                _dbContext
                .Images
                .Skip(start)
                .Take(end - start)
                .AsQueryable();
        }

        public IQueryable<Image> GetImagesByCategoryAsync(Categories category, int start, int end)
        {
            return
                _dbContext
                .Images
                .Where(img => img.Category == category)
                .Skip(start)
                .Take(end - start)
                .AsQueryable();
        }

        public IQueryable<Image> GetImagesByDateAsync(DateTime date, int start, int end)
        {
            return 
                _dbContext
                .Images
                .Where(img =>
                img.UploadDate.Year == date.Year &&
                img.UploadDate.Month == date.Month &&
                img.UploadDate.Day == date.Day)
                .Skip(start)
                .Take(end - start)
                .AsQueryable();
        }

        public IQueryable<Image> GetImagesByUserAsync(string userId, int start, int end)
        {
            return _dbContext
                .Images
                .Where(img => img.UserId == userId)
                .Skip(start)
                .Take(end - start)
                .AsQueryable();
        }
    }
}
