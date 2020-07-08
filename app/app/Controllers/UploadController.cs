using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using app.data_access.Models;
using app.services.Interfaces;
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

        private IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private IUploadService _uploadService;

        public UploadController(IWebHostEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager, IUploadService uploadService)
        {
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
            _uploadService = uploadService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult> UploadFilesAsync(UploadRequest request)
        {
            try
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.UploadedFile.FileName.Split("\\").Last();
                var filePath = Path.Combine(uploads, uniqueFileName);
                await request.UploadedFile.CopyToAsync(new FileStream(filePath, FileMode.Create));

                await _uploadService.HandleFileUploadAsync(request, filePath);


                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
