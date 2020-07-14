using System;
using System.Threading.Tasks;
using app.data_access.Data;
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
        public async Task<IActionResult> GetImages()
        {
            return Ok(await _service.GetImageUrlsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetImagesByCategory(Category category)
        {
            return Ok(await _service.GetImageUrlsByCategoryAsync(category));
        }

        [HttpGet]
        public async Task<IActionResult> GetImagesByDate(DateTime date)
        {
            return Ok(await _service.GetImageUrlsByDateAsync(date));
        }

        [HttpGet]
        public async Task<IActionResult> GetImagesByUser(string userId)
        {
            return Ok(await _service.GetImageUrlsByUserAsync(userId));
        }
    }
}
