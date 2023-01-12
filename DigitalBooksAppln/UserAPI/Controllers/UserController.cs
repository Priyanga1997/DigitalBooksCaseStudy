using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration _config;
        IUser _user;
        public UserController(IConfiguration config, IUser user)
        {
            _config = config;
            _user = user;
        }

        [HttpPost]
        [Route("User/Login")]
        public async Task<IActionResult> LoginAsync(User login)
        {
            try
            {
                IActionResult response = Unauthorized();
                var userdata = await _user.LoginAsync(login, false);
                if (login != null)
                {
                    response = Ok(new { token = userdata });
                }
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("User/Register")]
        public async Task<IActionResult> RegisterAsync(User login)
        {
            try
            {
                IActionResult response = Unauthorized();
                var userdata = await _user.RegisterAsync(login, true);
                if (login != null)
                {
                    response = Ok(new { token = userdata });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to register {ex.Message}");
            }
        }
    }
}

