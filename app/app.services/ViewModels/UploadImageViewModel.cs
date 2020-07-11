using app.data_access.Models;
using Microsoft.AspNetCore.Http;

namespace app.services.ViewModels
{
    public class UploadImageViewModel
    {
        public IFormFile UploadedFile { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }
    }
}
