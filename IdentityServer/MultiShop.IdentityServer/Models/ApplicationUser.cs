using Microsoft.AspNetCore.Identity;

namespace MultiShop.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    // bu benim app user sınıfına karşılık gelen oluyor
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
