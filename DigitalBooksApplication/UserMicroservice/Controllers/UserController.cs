using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net;
using System.Text;
using UserMicroservice.Models;
using UserMicroservice.Services;

namespace UserMicroservice.Controllers
{
    public class UserController : Controller
    {
        public IConfiguration _config;
        IUser _user;
        public UserController(IConfiguration config, IUser user)
        {
            _config = config;
            _user = user;
        }

        [HttpGet]
        [Route("User/Login")]
        public IActionResult Login()
        {
            User login = new User();
            return View(login);
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
                    if(login.UserType == "author")
                    {
                        return RedirectToAction("CallPostAPI", "Books", new { token = userdata });
                    }
                    if (login.UserType == "reader")
                    {
                        return RedirectToAction("Index", "Home", new { token = userdata });
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("User/Register")]
        public IActionResult Register()
        {
            User login = new User();
            return View(login);
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
                //return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to register {ex.Message}");
            }
        }      
    }
}
