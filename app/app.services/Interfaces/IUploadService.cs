using app.data_access.Models;
using System.IO;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IUploadService
    {
        Task HandleFileUploadAsync(UploadImageViewModel request);
        Task CompressAsync(FileInfo fileToCompress);
    }
}
