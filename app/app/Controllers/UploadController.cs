using System;
using System.Threading.Tasks;
using app.data_access.Models;
using app.services.Interfaces;
using app.services.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IUploadService _uploadService;

        public UploadController(UserManager<ApplicationUser> userManager, IUploadService uploadService)
        {
            _userManager = userManager;
            _uploadService = uploadService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult> UploadFilesAsync(UploadImageViewModel request)
        {
            try
            {
                await _uploadService.HandleFileUploadAsync(request);
                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
