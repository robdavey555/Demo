using Eintech.App.Models;
using Eintech.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Eintech.Services;
using System.Collections.Generic;
using System.Linq;

namespace Eintech.App.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IGroupService _groupService;
        public PeopleController(IPersonService personService, IGroupService groupService)
        {
            _personService = personService;
            _groupService = groupService;
        }

        public IActionResult Index(string searchName, string searchGroup)
        {
            PeopleViewModel model = new PeopleViewModel()
            {
                People = (string.IsNullOrEmpty(searchName) && string.IsNullOrEmpty(searchGroup)) ?
                                                        _personService.GetAll() :
                                                        _personService.Search(searchName, searchGroup)
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel model = new CreatePersonViewModel()
            {
                Groups = GetGroups()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name, GroupId")] PersonDTO person)
        {
            if (ModelState.IsValid)
            {
                _personService.Add(person);

                return RedirectToAction("Index", "People");
            }

            return View(new CreatePersonViewModel() { Person = person, Groups = GetGroups() });
        }

        private List<SelectListItem> GetGroups()
        {
            return _groupService.GetAll().Select(a =>
                    new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Name
                    }).ToList();
        }
    }
}