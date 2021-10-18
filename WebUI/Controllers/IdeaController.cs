using Application.DTO_Models;
using Application.Services.Interfaces;
using Application.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class IdeaController : Controller
    {
        private readonly IIdeaService _ideaService;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly string _token = "token";
        public IdeaController(IIdeaService ideaService, IMapper mapper, IAuthenticationService authenticationService)
        {
            _ideaService = ideaService;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

            if (tokenFromCookie == null || userId == Guid.Empty) return RedirectToAction("Login", "User");

            List<IdeaViewModel> ideasVm = _mapper.Map<List<IdeaViewModel>>(_ideaService.GetAll(userId));

            return View(new IdeaHomeViewModel()
            {
                ideasViewModel = ideasVm
            });
        }

        [HttpPost]
        public IActionResult AddNewIdea([FromBody] IdeaViewModel ideaVm)
        {
            if (ModelState.IsValid)
            {
                var tokenFromCookie = Request.GetCookie(_token);
                var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

                if (tokenFromCookie == null || userId == Guid.Empty) return RedirectToAction("Login", "User");

                var idea = _mapper.Map<IdeaDTO>(ideaVm);
                idea.UserId = userId;

                var result = _ideaService.Add(idea);

                if (result) return Json(new { status = "Success", message = "Idea added successfully!" });
            }

            return Json(new { status = "Error", message = "Adding was unsuccessful. Idea with same unique key already exists!" });

        }

        public IActionResult DeleteIdea(Guid id)
        {
            var tokenFromCookie = Request.GetCookie(_token);
            var userId = _authenticationService.GetUserIdFromToken(tokenFromCookie);

            if (tokenFromCookie == null || userId == Guid.Empty) return RedirectToAction("Login", "User");

            _ideaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
