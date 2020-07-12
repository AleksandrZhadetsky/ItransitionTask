using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using app.data_access.Models;
using app.services.Interfaces;
using app.services.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private const int CategoryItems = 10;
        private const int DefaultCategory = 9;

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
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
