using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.data_access.Models;
using app.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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


        [Route("getImage")]
        [HttpGet]
        public async Task<Image> GetImage([FromQuery] Guid id)
        {
            return await _service.GetImageAsync(id);
        }

        [Route("getImages")]
        [HttpGet]
        public async Task<IEnumerable<Image>> GetImages([FromQuery] int start, int end, Categories category)
        {
            return await _service.GetImagesAsync(start, end, category);
        }

        [HttpGet]
        public Task<IEnumerable<Image>> GetImagesByDate([FromQuery] DateTime date, int start, int end)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<IEnumerable<Image>> GetImagesByUser([FromQuery] string userId, int start, int end)
        {
            throw new NotImplementedException();
        }
    }
}
