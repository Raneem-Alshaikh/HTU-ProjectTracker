using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.DTO;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    public class DeveloperController : Controller
    {
        private IDeveloperRepository developerRepository;

        public DeveloperController(IDeveloperRepository developerRepository)
        {
            this.developerRepository = developerRepository;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> InsertDeveloper(CreateUserDto deverloperDto)
        {
            if (ModelState.IsValid)
            {
                await developerRepository.InsertDeveloper(deverloperDto);
                return RedirectToAction("ShowDevelopers");
            }
            else
                return View("Create");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ShowDevelopers()
        {
            ViewBag.Developers = developerRepository.GetDevelopers();
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDeveloper(string Id)
        {
            developerRepository.DeleteDeveloper(Id);
            return RedirectToAction("ShowDevelopers");
        }

        [Authorize(Roles ="Admin")]
        public IActionResult ShowEditDeveloper(string developerId)
        {
            var developer = developerRepository.GetDeveloper(developerId);
            EditUserDto developerDto = new EditUserDto()
            {
                Id = developer.Id,
                FirstName = developer.FirstName,
                LastName = developer.LastName,
                Email = developer.Email,
                Age = developer.Age
            };
            return View("Edit", developerDto);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult ApplayEdit(EditUserDto deverloperDto)
        {
            if (ModelState.IsValid)
            {

                developerRepository.EditDeveloper(deverloperDto);
                return RedirectToAction("ShowDevelopers");
            }
            else
                return View("Edit");
        }
    }
}

