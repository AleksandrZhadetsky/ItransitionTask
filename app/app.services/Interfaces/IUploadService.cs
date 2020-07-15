using app.services.ViewModels;
using Microsoft.AspNetCore.Http;
using PhotoSauce.MagicScaler;
using System.IO;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IUploadService
    {
        Task HandleFileUploadAsync(UploadImageViewModel request);
        Task<ProcessImageResult> ProcessImageAsync(IFormFile source, FileStream outStream, ProcessImageSettings settings);
    }
}
