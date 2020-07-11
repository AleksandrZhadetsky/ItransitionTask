using app.data_access.Models;
using app.services.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IUploadService
    {
        Task HandleFileUploadAsync(UploadImageViewModel request);
        Task<string> CompressAsync(IFormFile fileToCompress);
    }
}
