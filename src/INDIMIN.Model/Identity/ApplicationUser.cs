using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace INDIMIN.Model.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public List<ApplicationUserRole> UserRoles { get; set; }
    }
}
