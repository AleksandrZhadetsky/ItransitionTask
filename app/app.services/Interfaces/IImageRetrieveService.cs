using app.data_access.Models;
using System;
using System.Linq;

namespace app.services.Interfaces
{
    public interface IImageRetrieveService
    {
        IQueryable<Image> GetImagesAsync(int start, int end);
        IQueryable<Image> GetImagesByCategoryAsync(Categories category, int start, int end);
        IQueryable<Image> GetImagesByUserAsync(string userId, int start, int end);
        IQueryable<Image> GetImagesByDateAsync(DateTime date, int start, int end);
    }
}
