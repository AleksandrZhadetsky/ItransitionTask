using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.data_access.Models;
using app.services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Image>> GetImages(int start, int end)
        {
            return await _service.GetImagesAsync(start, end).ToListAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<Image>> GetImagesByCategory(Categories category, int start, int end)
        {
            return await _service.GetImagesByCategoryAsync(category, start, end).ToListAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<Image>> GetImagesByDate(DateTime date, int start, int end)
        {
            return await _service.GetImagesByDateAsync(date, start, end).ToListAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<Image>> GetImagesByUser(string userId, int start, int end)
        {
            return await _service.GetImagesByUserAsync(userId, start, end).ToListAsync();
        }
    }
}
