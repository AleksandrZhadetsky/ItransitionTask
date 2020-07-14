using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.data_access.Models;
using app.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.ClientApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRetrieveService _service;

        public ImagesController(IImageRetrieveService imageRetrieveService)
        {
            _service = imageRetrieveService;
        }

        [HttpGet]
        public Task<IEnumerable<string>> GetImages()
        {
            return _service.GetImageUrlsAsync();
        }

        [HttpGet]
        public Task<IEnumerable<string>> GetImagesByCategory(Category category)
        {
            return _service.GetImageUrlsByCategoryAsync(category);
        }

        [HttpGet]
        public Task<IEnumerable<string>> GetImagesByDate(DateTime date)
        {
            return _service.GetImageUrlsByDateAsync(date);
        }

        [HttpGet]
        public Task<IEnumerable<string>> GetImagesByUser(string userId)
        {
            return _service.GetImageUrlsByUserAsync(userId);
        }
    }
}
