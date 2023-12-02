using Microsoft.AspNetCore.Identity;

namespace zdt_application.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public bool IsActive { get; set; }
        public bool? isLoggedIn { get; set; }
    }
}
