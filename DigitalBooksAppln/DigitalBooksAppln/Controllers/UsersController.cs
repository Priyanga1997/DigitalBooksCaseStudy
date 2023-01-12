﻿using DigitalBooksAppln.Models;
using DigitalBooksAppln.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

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

        [Route("Users/Login")]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [Route("Users/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(User login)
        {
            try
            {
                IActionResult response = Unauthorized();
                var userdata = await _user.LoginAsync(login, false);
                //string userid = HttpContext.User.Identity.Name;
                _httpContextAccessor.HttpContext.Session.SetString("token", userdata.token.ToString());
                _httpContextAccessor.HttpContext.Session.SetString("emailId", login.EmailId.ToString());
                _httpContextAccessor.HttpContext.Session.SetString("username", login.UserName.ToString());
                _httpContextAccessor.HttpContext.Session.SetString("userId", userdata.User.UserId.ToString());

                if (login != null)
                {
                    if (login.UserType == "author")
                    {
                        return RedirectToAction("Create", "Books", new { token = userdata, emailId =login.EmailId ,username = login.UserName, userId=login.UserId }) ;
                    }
                    if (login.UserType == "reader")
                    {
                        return RedirectToAction("Search", "Books", new { token = userdata, emailId = login.EmailId, username = login.UserName,userId=login.UserId });
                    }
                    if (login.UserType == "admin")
                    {
                        return RedirectToAction("AdminView", "Books", new { token = userdata, emailId = login.EmailId, username = login.UserName});
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

        [Route("Users/Register")]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

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


