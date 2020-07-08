using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Path { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime UploadDate { get; set; }
        public Category Category { get; set; } = Category.Other;
    }
}
