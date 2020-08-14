using app.data_access.Data;
using app.data_access.Models;
using app.services.Interfaces;
using app.services.Repositories;
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
        private readonly IImageRetrieveSqlRepository _repository;
        private IWebHostEnvironment _hostingEnvironment;

        public UploadService(IWebHostEnvironment hostingEnvironment, IImageRetrieveSqlRepository repository)
        {
            _hostingEnvironment = hostingEnvironment;
            _repository = repository;
        }

        public async Task HandleFileUploadAsync(UploadImageViewModel request)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, Constants.Constants.UploadsFolder);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.UploadedFile.FileName.Split("\\").Last();
            var filePath = Path.Combine(uploads, uniqueFileName);
            var relativeImageUrl = Path.Combine(Constants.Constants.UploadsFolder, uniqueFileName);

            var settings = new ProcessImageSettings { Width = 500 };

            using (var outStream = File.Create(filePath))
            {
                await ProcessImageAsync(request.UploadedFile, outStream, settings);
            }

            var dbImage =
                new Image
                {
                    Path = relativeImageUrl,
                    UserId = request.UserId,
                    UploadDate = DateTime.Now,
                    Category = request.Category
                };

            await _repository.CreateAsync(dbImage);
        }

        public Task<ProcessImageResult> ProcessImageAsync(IFormFile source, FileStream outStream, ProcessImageSettings settings) =>
            Task.Run(() => MagicImageProcessor.ProcessImage(source.OpenReadStream(), outStream, settings));
    }
}
