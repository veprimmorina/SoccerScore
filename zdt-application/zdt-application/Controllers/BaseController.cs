using HRM.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using zdt_application.Auth;
using zdt_application.Data;

namespace zdt_application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly IConfiguration _configuration;
        protected UserDto loggedUser;

        public BaseController(UserManager<ApplicationUser> userManager,

                             IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> CheckConnectivity()
        {
            return Ok();
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            // Get Language from Cookies
            //var l = Request.Cookies["lang"];
          

            //Get Logged User
            var jwt = Request.Cookies["jwt"];
            var token = Verify(jwt);
            if (token != null)
            {
                var userName = token.Claims.ToList()[0].Value;
                var user = await _userManager.FindByNameAsync(userName);
                var role = await _userManager.GetRolesAsync(user);
                loggedUser = new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Token = jwt,
                    Role = role.First()
                };

            }

            #region --> log request <-- 
            //string controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            //string actionName = ControllerContext.RouteData.Values["action"].ToString();
            //string url = filterContext.HttpContext.Request.GetDisplayUrl();
           // Log log = new Log();

            //if (filterContext.HttpContext.Request.HasFormContentType)
            //{
            //    IFormCollection form = await filterContext.HttpContext.Request.ReadFormAsync();
            //   // log.PostedData = JsonConvert.SerializeObject(form);
            //}

            //log.UserId = user.Id;
            //log.UserId = loggedUser != null ? loggedUser.Email : "1";
            //log.Ip = filterContext.HttpContext.Connection.RemoteIpAddress.ToString();
            //log.HostName = filterContext.HttpContext.Connection.RemoteIpAddress.ToString();
            //log.Controller = controllerName;
            //log.Action = actionName;
            //log.Url = url;
            //log.IsError = false;
            //log.LogTime = DateTime.Now;

            var context = await next();

            if (context.Exception is Exception exception)
            {
                context.ExceptionHandled = true;
                //log.Description = Newtonsoft.Json.JsonConvert.SerializeObject(exception);
                //log.IsError = true;
                context.Result = new BadRequestResult();

             }

                //using (var db = new DBContext())
                //{
                //    db.Logs.Add(log);
                //    await db.SaveChangesAsync();
                //}

                #endregion
            }

        protected JwtSecurityToken Verify(string jwt)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
                tokenHandler.ValidateToken(jwt, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return (JwtSecurityToken)validatedToken;
            }
            catch (SecurityTokenExpiredException)
            {
                // Token expired exception
                // You could return a special indication that the token is expired or log it as needed.
                return null;
            }
            catch (Exception ex)
            {
                // Other exceptions
                return null;
            }


        }

        protected async Task<List<Claim>> getUserClaims(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims;
        }

        protected JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(45),
                claims: authClaims,

                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        protected static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        protected ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }

        protected void deleteCookies()
        {
            Response.Cookies.Delete("jwt", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });
            Response.Cookies.Delete("refresh", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });
        }


    }
}
