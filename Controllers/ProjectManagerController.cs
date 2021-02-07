using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.DTO;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ProjectManagerController : Controller
    {
        private IProjectManagerRepository projectManagerRepository;

        public ProjectManagerController(IProjectManagerRepository projectManagerRepository)
        {
            this.projectManagerRepository = projectManagerRepository;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> InsertProjectManager(CreateUserDto projectManagerDto)
        {
            if (ModelState.IsValid)
            {
                await projectManagerRepository.InsertProjectManager(projectManagerDto);
                return RedirectToAction("ShowProjectManagers");
            }
            else
                return View("Create");
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult ShowProjectManagers()
        {
            ViewBag.ProjectManagers = projectManagerRepository.GetProjectManagers();
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProjectManager(string Id)
        {
            projectManagerRepository.DeleteProjectManager(Id);
            return RedirectToAction("ShowProjectManagers");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ShowEditProjectManager(string projectManagerId)
        {
            var projectManager = projectManagerRepository.GetProjectManager(projectManagerId);
            EditUserDto projectManagerDto = new EditUserDto()
            {
                Id = projectManager.Id,
                FirstName = projectManager.FirstName,
                LastName = projectManager.LastName,
                Email = projectManager.Email,
                Age = projectManager.Age
            };
            return View("Edit", projectManagerDto);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ApplayEdit(EditUserDto projectManagerDto)
        {
            if (ModelState.IsValid)
            {
                projectManagerRepository.EditProjectManager(projectManagerDto);
                return RedirectToAction("ShowProjectManagers");
            }
            else
                return View("Edit");
        }
    }
}
