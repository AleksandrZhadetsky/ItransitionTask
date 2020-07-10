using app.services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace app.services.Services
{
    public class DownloadService : IDownloadService
    {
        public Task<byte[]> HandleFileDownloadAsync(Guid fileId)
        {
            throw new NotImplementedException();
        }

        public async Task DecompressAsync(byte[] buffer, FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        await decompressionStream.ReadAsync(buffer);
                    }
                }
            }
        }
    }
}
