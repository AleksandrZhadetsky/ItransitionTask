using app.data_access.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IImageRetrieveService
    {
        Task<IEnumerable<string>> GetImageUrlsAsync();
        Task<IEnumerable<string>> GetImageUrlsByCategoryAsync(Category category);
        Task<IEnumerable<string>> GetImageUrlsByUserAsync(string userId);
        Task<IEnumerable<string>> GetImageUrlsByDateAsync(DateTime date);
    }
}
