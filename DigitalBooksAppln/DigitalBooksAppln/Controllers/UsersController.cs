using DigitalBooksAppln.Models;
using DigitalBooksAppln.Services;
using Microsoft.AspNetCore.Mvc;
namespace DigitalBooksAppln.Controllers
{
    public class UsersController : Controller
    {
        public IConfiguration _config;
        IUsers _user;
        public IHttpContextAccessor _httpContextAccessor;
        public UsersController(IConfiguration config, IUsers user, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _user = user;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// This method is used to display the login view
        /// </summary>
        /// <returns></returns>
        [Route("Users/Login")]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        /// <summary>
        /// This method is used for login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Route("Users/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(User login)
        {
            try
            {
                IActionResult response = Unauthorized();
                var userdata = await _user.LoginAsync(login, false);
                _httpContextAccessor.HttpContext.Session.SetString("token", userdata.token.ToString());
                _httpContextAccessor.HttpContext.Session.SetString("emailId", login.EmailId.ToString());
                _httpContextAccessor.HttpContext.Session.SetString("username", login.UserName.ToString());
                _httpContextAccessor.HttpContext.Session.SetString("userId", userdata.User.UserId.ToString());

                if (login != null)
                {
                    if (login.UserType == "author")
                    {
                        return RedirectToAction("Create", "Books", new { token = userdata, emailId = login.EmailId, username = login.UserName, userId = login.UserId });
                    }
                    if (login.UserType == "reader")
                    {
                        return RedirectToAction("Search", "Books", new { token = userdata, emailId = login.EmailId, username = login.UserName, userId = login.UserId });
                    }
                    if (login.UserType == "admin")
                    {
                        return RedirectToAction("AdminView", "Books", new { token = userdata, emailId = login.EmailId, username = login.UserName ,userId=login.UserId});
                    }
                    response = Ok(new { token = userdata });
                }
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This method is used to display register view
        /// </summary>
        /// <returns></returns>
        [Route("Users/Register")]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        /// <summary>
        /// This method is used for register
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Route("Users/Register")]
        [HttpPost]
        public async Task<IActionResult> Register(User login)
        {
            try
            {
                IActionResult response = Unauthorized();
                var userdata = await _user.RegisterAsync(login, true);
                if (login != null)
                {
                    response = Ok(new { token = userdata });
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to register {ex.Message}");
            }
        }
    }
}


