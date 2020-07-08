using app.data_access.Models;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IUploadService
    {
        Task HandleFileUploadAsync(UploadRequest request, string pathToUploadFolder);
    }
}
