using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.data_access.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public string Token { get; set; }
        [NotMapped]
        public string Role { get; set; }
        public List<Image> Images { get; set; }
    }
}
