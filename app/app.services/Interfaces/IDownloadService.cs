using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IDownloadService
    {
        Task<byte[]> HandleFileDownloadAsync(Guid imageId);
        Task DecompressAsync(byte[] buffer, FileInfo fileToDecompress);
    }
}
