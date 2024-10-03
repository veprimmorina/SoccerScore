using HRM.DTOs;
using HRM.Models;
using Microsoft.AspNetCore.Identity;
using zdt_application.Models;

namespace zdt_application.Application.Services.Base
{
    public interface IAuthService
    {
        Task<UserDto> LoginWithUsernameAndPassword(LoginModel model);
        Task<IdentityResult> Register(RegisterModel model);
    }

}
