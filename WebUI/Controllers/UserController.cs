using Application.DTO_Models;
using Application.Services.Interfaces;
using Application.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly string _token = "token";
        public UserController(IUserService userService, IMapper mapper, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

            if (tokenFromCookie != "" && userId != Guid.Empty) return RedirectToAction("Index", "Idea");

            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel userVm)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", userVm);
            }

            var user = _userService.LogIn(_mapper.Map<UserDTO>(userVm));

            if (user == null) return View("CustomErrorPage", new CustomErrorPageViewModel()
            {
                Title="Login Error",
                Desctiption="Ivalid username or password. Please try again!"
            });

            Response.SetCookie(_token, user.Id);

            return RedirectToAction("Index", "Idea");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

            if (tokenFromCookie != "" && userId != Guid.Empty) return RedirectToAction("Index", "Idea");

            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterViewModel userVm)
        {
            if (!ModelState.IsValid)
            {
                 return View("Register");
            }

            var user = _userService.Register(_mapper.Map<UserDTO>(userVm));

            if (user == null) return View("CustomErrorPage", new CustomErrorPageViewModel()
            {
                Title = "Registering Error",
                Desctiption = "The user already exists! Please try again."
            });

            Response.SetCookie(_token, user.Id);
            return RedirectToAction("Index", "Idea");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(_token);

            return RedirectToAction("Login", "User");
        }
    }
}
