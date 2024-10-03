using HRM.DTOs;
using HRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zdt_application.Application.Services.Base;
using zdt_application.Controllers.Base;
using zdt_application.Models;

namespace zdt_application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthenticateController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("LoginWithUsernameAndPassword")]
        public async Task<ActionResult<UserDto>> LoginWithUsernameAndPassword([FromForm] LoginModel model)
        {
            var result = await _authService.LoginWithUsernameAndPassword(model);
            if (!string.IsNullOrEmpty(result.Username))
            {
                return Ok(new { message = result.Username });
            }

            Response.Cookies.Append("jwt", result.Token, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });

            return Ok(new { username = result.Username, role = result.Role, Token = result.Token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authService.Register(registerModel);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = result.Errors.FirstOrDefault()?.Description });
            }

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }
    }
}
