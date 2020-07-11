using app.data_access.Data;
using app.data_access.Models;
using app.services.Constants;
using app.services.Interfaces;
using app.services.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            var extension = request.UploadedFile.FileName.Split('.').Last();
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, Constants.Constants.UploadsFolder);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.UploadedFile.FileName.Split("\\").Last();
            var filePath = Path.Combine(uploads, uniqueFileName);

            if (request.UploadedFile.Length < Constants.Constants.FileLengthMaxValue)
            {
                var dbImage =
                    new Image
                    {
                        Path = filePath,
                        UserId = request.UserId,
                        UploadDate = DateTime.Now,
                        Category = request.Category,
                        Compressed = false,
                        TargetExtension = extension
                    };

                _dbContext.Images.Add(dbImage);
                await _dbContext.SaveChangesAsync();
                await request.UploadedFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }
            else
            {
                filePath = await CompressAsync(request.UploadedFile);

                var dbImage =
                    new Image
                    {
                        Path = filePath,
                        UserId = request.UserId,
                        UploadDate = DateTime.Now,
                        Category = request.Category,
                        Compressed = true,
                        TargetExtension = extension
                    };

                _dbContext.Images.Add(dbImage);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<string> CompressAsync(IFormFile fileToCompress)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, Constants.Constants.UploadsFolder);
            var filenameWithoutExtension = fileToCompress.FileName.Split('.').First();
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + filenameWithoutExtension.Split("\\").Last();
            var filePath = Path.Combine(uploads, $"{uniqueFileName}.gz");

            using (FileStream compressedFileStream = File.Create(filePath))
            {
                using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                {
                    await fileToCompress.CopyToAsync(compressionStream);
                }
            }

            return filePath;
        }
    }
}
