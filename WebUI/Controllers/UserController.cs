using Application.DTO_Models;
using Application.Services.Interfaces;
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
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
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

            return RedirectToAction("Index", "Idea");
        }

        [HttpGet]
        public IActionResult Register()
        {
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

            return RedirectToAction("Index", "Idea");
        }
    }
}
