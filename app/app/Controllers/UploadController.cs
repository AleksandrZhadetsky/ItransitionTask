using System;
using System.Threading.Tasks;
using app.services.Interfaces;
using app.services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFilesAsync(UploadImageViewModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _uploadService.HandleFileUploadAsync(request);
                    return Ok("File successfully uploaded");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Invalid model state");
            }
        }
    }
}
