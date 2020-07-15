using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.data_access.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime UploadDate { get; set; }
        public Categories Category { get; set; } = Categories.Other;
    }
}
