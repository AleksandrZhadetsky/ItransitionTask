using app.data_access.Data;
using app.data_access.Models;
using app.services.Constants;
using app.services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace app.services.Services
{
    public class UploadService : IUploadService
    {
        private ApplicationDbContext _dbContext;
        private IWebHostEnvironment _hostingEnvironment;

        public UploadService(IWebHostEnvironment hostingEnvironment, ApplicationDbContext dbContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbContext = dbContext;
        }

        public async Task HandleFileUploadAsync(UploadImageViewModel request)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, Constants.Constants.UploadsFolder);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.UploadedFile.FileName.Split("\\").Last();
            var filePath = Path.Combine(uploads, uniqueFileName);
            await request.UploadedFile.CopyToAsync(new FileStream(filePath, FileMode.Create));

            var dbImage = new Image { Path = filePath, UserId = request.UserId, UploadDate = DateTime.Now, Category = request.Category };

            _dbContext.Images.Add(dbImage);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CompressAsync(FileInfo fileToCompress)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, Constants.Constants.UploadsFolder);
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {
                    using (FileStream compressedFileStream = File.Create(uploads + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz")) // should remove the previous extension from fileName
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            await originalFileStream.CopyToAsync(compressionStream);
                        }
                    }
                }
            }
        }
    }
}
