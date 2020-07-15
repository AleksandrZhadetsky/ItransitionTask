using app.data_access.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace app.services.ViewModels
{
    public class UploadImageViewModel
    {
        [Required]
        public IFormFile UploadedFile { get; set; }

        [Required]
        public Categories Category { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
