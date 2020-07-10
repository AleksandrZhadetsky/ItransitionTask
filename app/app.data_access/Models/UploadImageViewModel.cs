using Microsoft.AspNetCore.Http;

namespace app.data_access.Models
{
    public class UploadImageViewModel
    {
        public IFormFile UploadedFile { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }
    }
}
