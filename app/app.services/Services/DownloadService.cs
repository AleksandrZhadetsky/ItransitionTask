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
            var filePath = dbImage.Path;
            var buffer = await File.ReadAllBytesAsync(dbImage.Path);

            return buffer;
        }

        public async Task<string> DecompressAsync(FileInfo fileToDecompress)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetImageUrlsAsync()
        {
            return await _dbContext.Images.Select(img => img.Path).ToListAsync();
        }
    }
}
