using app.data_access.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IImageRetrieveService
    {
        Task<Image> GetImageAsync(Guid id);
        Task<IEnumerable<Image>> GetImagesAsync(int start, int end, Categories category);
        Task<IEnumerable<Image>> GetImagesByUserAsync(string userId, int start, int end);
        Task<IEnumerable<Image>> GetImagesByDateAsync(DateTime date, int start, int end);
    }
}
