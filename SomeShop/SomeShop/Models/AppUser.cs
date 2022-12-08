using Microsoft.AspNetCore.Identity;

namespace SomeShop.Models
{
    public class AppUser:IdentityUser
    {
        public string Occupation { get; set; }
    }
}
