using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using zdt_application.Application.Services.Authentication;

namespace zdt_application.Controllers.Base
{
    public class CustomActionFilter : IAsyncActionFilter
    {
        private readonly TokenService _tokenService;
        private readonly UserService _userService;
        private readonly CookieService _cookieService;

        public CustomActionFilter(TokenService tokenService, UserService userService, CookieService cookieService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _cookieService = cookieService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var jwt = _cookieService.GetCookie("jwt");
            if (!string.IsNullOrEmpty(jwt))
            {
                var token = _tokenService.VerifyToken(jwt);
                if (token != null)
                {
                    var loggedUser = await _userService.GetLoggedUserFromToken(jwt, token);
                    if (loggedUser != null)
                    {
                        context.HttpContext.Items["LoggedUser"] = loggedUser;
                    }
                }
            }

            var executedContext = await next();

            if (executedContext.Exception != null)
            {
                executedContext.ExceptionHandled = true;
                executedContext.Result = new BadRequestResult();
            }
        }
    }
}