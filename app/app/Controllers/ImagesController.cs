using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.data_access.Data;
using app.services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app.ClientApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private readonly IDownloadService _downloadService;

        public ImagesController(ApplicationDbContext dbContext, IDownloadService downloadService)
        {
            _dbContext = dbContext;
            _downloadService = downloadService;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadImageAsync(Guid imageId)
        {
            return Ok(await _downloadService.HandleFileDownloadAsync(imageId));
        }

        [HttpGet]
        public async Task<IActionResult> GetImageUrls()
        {
            return Ok(await _downloadService.GetImageUrlsAsync());
        }

        // TODO: add endpoints to get images grouped by category and etc.
    }
}
