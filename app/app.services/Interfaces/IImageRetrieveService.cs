using app.data_access.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IImageRetrieveService
    {
        Task<IList<string>> GetImageUrlsAsync();
        Task<IList<string>> GetImageUrlsByCategoryAsync(Category category);
        Task<IList<string>> GetImageUrlsByUserAsync(string userId);
        Task<IList<string>> GetImageUrlsByDateAsync(DateTime date);
    }
}
