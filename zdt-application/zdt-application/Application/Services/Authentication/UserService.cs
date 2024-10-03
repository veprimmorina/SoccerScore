using HRM.DTOs;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using zdt_application.Auth;

namespace zdt_application.Application.Services.Authentication
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto?> GetLoggedUserFromToken(string jwt, JwtSecurityToken token)
        {
            var userName = token.Claims.FirstOrDefault()?.Value;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    return new UserDto
                    {
                        Id = user.Id,
                        Username = user.UserName,
                        Email = user.Email,
                        Token = jwt,
                        Role = roles.FirstOrDefault()
                    };
                }
            }
            return null;
        }

        public async Task<List<Claim>> GetUserClaims(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            return authClaims;
        }
    }

}