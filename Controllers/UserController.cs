using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("GetCurrentDateTime")]
        public IActionResult GetDateTime()
        {
            var obj = new
            {
                Date = DateTime.Now.ToLongDateString(),
                Time = DateTime.Now.ToShortTimeString(),
            };

            return Ok(obj);
        }

        [HttpGet("Welcome/{name}")]
        public IActionResult Welcome(string name)
        {
            var message = $"Hello {name}, welcome!";

            return Ok(new { message });
        }
    }
}