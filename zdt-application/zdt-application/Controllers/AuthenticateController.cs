using HRM.DTOs;
using HRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using zdt_application.Auth;
using zdt_application.Data;
using zdt_application.Models;

namespace zdt_application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly DBContext _context;
        private static ConcurrentDictionary<string, SemaphoreSlim> userSemaphores = new ConcurrentDictionary<string, SemaphoreSlim>();

        public AuthenticateController(
         UserManager<ApplicationUser> userManager,
         RoleManager<IdentityRole> roleManager,
         IWebHostEnvironment hostingEnvironment,
         //IEmailService emailService,
         IConfiguration configuration,
         DBContext context) : base(userManager, configuration)
        {
            _roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
            //_emailService = emailService;
            _context = context;
        }


        [AllowAnonymous]
        [HttpPost("LoginWithUsernameAndPassword")]
        public async Task<ActionResult<UserDto>> LoginWithUsernameAndPassword([FromForm] LoginModel model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Ok(new
                {
                    message = "There is no account with this username"
                });
            }

            var isCorrect = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isCorrect)
            {
                return Ok(new
                {
                    message = "Your password is wrong"
                });
            }

            //if (!user.EmailConfirmed)
            //{
            //    return Ok(new
            //    {
            //        message = "Please Confirm your email"
            //    });
            //}
            if (user.isLoggedIn == false)
            {

                var authClaims = await getUserClaims(user);
                var token = GetToken(authClaims);
                var refreshToken = GenerateRefreshToken();

                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
                user.isLoggedIn = true;
                await _userManager.UpdateAsync(user);

                deleteCookies();

                Response.Cookies.Append("jwt", value: new JwtSecurityTokenHandler().WriteToken(token), new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true
                });
                Response.Cookies.Append("refresh", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true
                });
                //var lang = Request.Cookies["lang"];
                //if (lang == null)
                //{
                //    Response.Cookies.Append("lang", "en-us", new CookieOptions
                //    {
                //        HttpOnly = true,
                //        SameSite = SameSiteMode.None,
                //        Secure = true
                //    });
                //    lang = "en-us";
                //}
                return Ok(new
                {
                    username = user.UserName,
                    role = authClaims[2].Value,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                   // Lang = lang
                    // RefreshToken = refreshToken,
                    //Expiration = token.ValidTo
                });
            }
            else
            {
                var authClaims = await getUserClaims(user);
                var token = GetToken(authClaims);
                Response.Cookies.Append("jwt", value: new JwtSecurityTokenHandler().WriteToken(token), new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true
                });
                var lang = Request.Cookies["lang"];
                if (lang == null)
                {
                    Response.Cookies.Append("lang", "en-us", new CookieOptions
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.None,
                        Secure = true
                    });
                    lang = "en-us";
                }
                if (user.RefreshTokenExpiryTime < DateTime.Now)
                {
                    var refreshToken = GenerateRefreshToken();

                    _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
                    user.RefreshToken = refreshToken;
                    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
                    await _userManager.UpdateAsync(user);
                    Response.Cookies.Append("refresh", refreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.None,
                        Secure = true
                    });
                }
                else
                {
                    Response.Cookies.Append("refresh", user.RefreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.None,
                        Secure = true
                    });
                }
                return Ok(new
                {
                    username = user.UserName,
                    role = authClaims[2].Value,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Lang = lang
                    // RefreshToken = refreshToken,
                    //Expiration = token.ValidTo
                });
            }
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });

            if (registerModel.Password != registerModel.ConfirmationPassword)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Confirmation Password must be same as Password!" });


            ApplicationUser user = new ApplicationUser()
            {
                Email = registerModel.Email,
                Id = Guid.NewGuid().ToString(),
                UserName = registerModel.Username,
                PhoneNumber = registerModel.PhoneNumber,
                FullName = registerModel.Name + " " + registerModel.Surname,
                IsActive = true,
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            // If you want to assign a role to the newly created user
            //if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            //await _userManager.AddToRoleAsync(user, UserRoles.User);

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }


        //        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        //        {
        //            if (tokenModel is null)
        //            {
        //                return BadRequest("Invalid client request");
        //            }

        //            string? accessToken = tokenModel.AccessToken;
        //            string? refreshToken = tokenModel.RefreshToken;

        //            var principal = GetPrincipalFromExpiredToken(accessToken);
        //            if (principal == null)
        //            {
        //                return BadRequest("Invalid access token or refresh token");
        //            }

        //#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        //#pragma warning disable CS8602 // Dereference of a possibly null reference.
        //            string username = principal.Identity.Name;
        //#pragma warning restore CS8602 // Dereference of a possibly null reference.
        //#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        //            var user = await _userManager.FindByNameAsync(username);

        //            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        //            {
        //                return BadRequest("Invalid access token or refresh token");
        //            }

        //            var newAccessToken = GetToken(principal.Claims.ToList());
        //            var newRefreshToken = GenerateRefreshToken();

        //            user.RefreshToken = newRefreshToken;
        //            await _userManager.UpdateAsync(user);

        //            return new ObjectResult(new
        //            {
        //                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
        //                refreshToken = newRefreshToken
        //            });
        //        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            var jwt = Request.Cookies["jwt"];
            var userClaims = GetPrincipalFromExpiredToken(jwt);
            var username = userClaims.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            user.isLoggedIn = false;
            await _userManager.UpdateAsync(user);
            deleteCookies();
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)

        {
            if (userId == null || code == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            await _userManager.ConfirmEmailAsync(user, code);

            return Ok();
        }
    }
}
