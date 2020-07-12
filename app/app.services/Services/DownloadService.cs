using app.data_access.Data;
using app.services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.services.Services
{
    public class DownloadService : IDownloadService
    {
        private IWebHostEnvironment _webHostEnvironment;
        private ApplicationDbContext _dbContext;

        public DownloadService(IWebHostEnvironment webHostEnvironment, ApplicationDbContext dbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _dbContext = dbContext;
        }

        public async Task<byte[]> HandleFileDownloadAsync(Guid fileId)
        {
            var dbImage = await _dbContext.Images.Where(img => img.Id == fileId).FirstOrDefaultAsync();
            var compressed = dbImage.Compressed;
            var targetExtension = dbImage.TargetExtension;
            var filePath = dbImage.Path;

            if (dbImage.Compressed)
            {
                var decompressedFilePath = await DecompressAsync(new FileInfo(dbImage.Path), targetExtension);
                
                var buffer = await File.ReadAllBytesAsync(decompressedFilePath);

                File.Delete(decompressedFilePath); // here delete the temp file

                return buffer;
            }
            else
            {
                var buffer = await File.ReadAllBytesAsync(dbImage.Path);

                return buffer;
            }
        }

        public async Task<string> DecompressAsync(FileInfo fileToDecompress, string targetExtension)
        {
            string currentFilePath = fileToDecompress.FullName;
            string newFilePath = currentFilePath.Remove(currentFilePath.Length - fileToDecompress.Extension.Length) + $".{targetExtension}";

            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                using (FileStream decompressedFileStream = File.Create(newFilePath))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        await decompressionStream.CopyToAsync(decompressedFileStream);
                    }
                }
            }

            return newFilePath;
        }

        public async Task<IEnumerable<string>> GetImageUrlsAsync()
        {
            return await _dbContext.Images.Select(img => img.Path).ToListAsync();
        }
    }
}
