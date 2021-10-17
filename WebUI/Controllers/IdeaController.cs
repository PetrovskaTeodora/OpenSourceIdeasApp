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
    public class IdeaController : Controller
    {
        private readonly IIdeaService _ideaService;
        private readonly IMapper _mapper;
        public IdeaController(IIdeaService ideaService, IMapper mapper)
        {
            _ideaService = ideaService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
           List<IdeaViewModel> ideasVm = _mapper.Map<List<IdeaViewModel>>(_ideaService.GetAll());

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
                var result = _ideaService.Add(_mapper.Map<IdeaDTO>(ideaVm));

                if (result) return Json(new { status = "Success", message = "Idea added successfully!" });
            }

            return Json(new { status = "Error", message = "Adding was unsuccessful. Please correct the errors and try again!" });

        }

        public IActionResult DeleteIdea(Guid id)
        {
            _ideaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
