using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IDownloadService
    {
        Task<byte[]> HandleFileDownloadAsync(Guid imageId);
        //Task<string> DecompressAsync(FileInfo fileToDecompress);
        Task<IList<string>> GetImageUrlsAsync();
    }
}
