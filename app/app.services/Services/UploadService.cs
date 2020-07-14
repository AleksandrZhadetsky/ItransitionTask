using app.data_access.Data;
using app.data_access.Models;
using app.services.Interfaces;
using app.services.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PhotoSauce.MagicScaler;
using System;
using System.IO;
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

            var settings = new ProcessImageSettings { Width = 500 };

            using (var outStream = File.Create(filePath))
            {
                await ProcessImageAsync(request.UploadedFile, outStream, settings);
            }

            var dbImage =
                new Image
                {
                    Path = filePath,
                    UserId = request.UserId,
                    UploadDate = DateTime.Now,
                    Category = request.Category == 0 ? Category.Other : request.Category
                };

            _dbContext.Images.Add(dbImage);
            await _dbContext.SaveChangesAsync();
        }

        public Task<ProcessImageResult> ProcessImageAsync(IFormFile source, FileStream outStream, ProcessImageSettings settings) =>
            Task.Run(() => MagicImageProcessor.ProcessImage(source.OpenReadStream(), outStream, settings));
    }
}
