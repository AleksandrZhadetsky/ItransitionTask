using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace app.data_access.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Image> Images { get; set; }
    }
}
