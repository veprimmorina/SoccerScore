using HRM.DTOs;
using HRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using zdt_application.Application.Services.Base;
using zdt_application.Auth;
using zdt_application.Models;

namespace zdt_application.Application.Services
{
    public class AuthenticationService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<UserDto> LoginWithUsernameAndPassword(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new UserDto {};
            }

            var isCorrect = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isCorrect)
            {
                return new UserDto {};
            }

            var authClaims = await GetUserClaims(user);
            var token = GetToken(authClaims);
            var refreshToken = GenerateRefreshToken();

            return new UserDto { Username = user.UserName, Role = authClaims[2].Value, Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }

        private async Task<List<Claim>> GetUserClaims(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1), 
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }


        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<IdentityResult> Register(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User already exists!" });
            }

            if (model.Password != model.ConfirmationPassword)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Confirmation Password must be the same as Password!" });
            }

            var user = new ApplicationUser
            {
                Email = model.Email,
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
                FullName = model.Name + " " + model.Surname,
                IsActive = true,
            };

            return await _userManager.CreateAsync(user, model.Password);
        }
    }

}