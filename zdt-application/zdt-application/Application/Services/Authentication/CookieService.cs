namespace zdt_application.Application.Services.Authentication
{
    public class CookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetCookie(string key)
        {
            return _httpContextAccessor.HttpContext?.Request.Cookies[key];
        }

        public void DeleteCookies()
        {
            var response = _httpContextAccessor.HttpContext?.Response;

            response?.Cookies.Delete("jwt", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });

            response?.Cookies.Delete("refresh", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });
        }
    }

}
