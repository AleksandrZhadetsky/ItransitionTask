using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using app.data_access.Models;
using app.services.Constants;
using app.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.ClientApp
{
    [Route("api/images")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRetrieveService _service;

        public ImagesController(IImageRetrieveService imageRetrieveService)
        {
            _service = imageRetrieveService;
        }

        [Route("getImages")]
        [HttpGet]
        public async Task<IEnumerable<Image>> GetImages([FromQuery] int start, int end, Categories category)
        {
            return await _service.GetImagesAsync(start, end, category);
        }

        [HttpGet]
        public async Task<IEnumerable<Image>> GetImagesByCategory([FromQuery] Categories category, int start, int end)
        {
            return await _service.GetImagesByCategoryAsync(category, start, end);
        }

        [HttpGet]
        public async Task<IEnumerable<Image>> GetImagesByDate([FromQuery] DateTime date, int start, int end)
        {
            return await _service.GetImagesByDateAsync(date, start, end);
        }

        [HttpGet]
        public async Task<IEnumerable<Image>> GetImagesByUser([FromQuery] string userId, int start, int end)
        {
            return await _service.GetImagesByUserAsync(userId, start, end);
        }
    }
}
