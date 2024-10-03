using Microsoft.AspNetCore.Mvc;
using zdt_application.Application.Wrappers;

namespace zdt_application.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected IActionResult CreateResponse<T>(BaseResponse<T> response)
        {
            if (response is null)
            {
                return NotFound();
            }

            if (response.StatusCode == (int)Application.Wrappers.StatusCodes.NotFound)
            {
                return NotFound(response);
            }

            if (response.StatusCode == (int)Application.Wrappers.StatusCodes.BadRequest)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}