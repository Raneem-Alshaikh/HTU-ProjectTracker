using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalProject.DTO;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinalProject.Controllers
{
    public class ProjectController : Controller
    {
        private ITeamLeaderRepository teamLeaderRepository;
        private IProjectRepository projectRepository;
        private IDeveloperRepository developerRepository;
        public ProjectController(ITeamLeaderRepository teamLeaderRepository, IProjectRepository projectRepository, IDeveloperRepository developerRepository)
        {
            this.teamLeaderRepository = teamLeaderRepository;
            this.projectRepository = projectRepository;
            this.developerRepository = developerRepository;
        }

        [Authorize(Roles="ProjectManager")]
        public IActionResult Create()
        {
            ViewBag.teamLeaders = teamLeaderRepository.GetTeamLeaders();
            ViewBag.developers = developerRepository.GetDevelopers();
            return View();
        }

        [Authorize(Roles = "ProjectManager")]
        public IActionResult InsertProject(CreateProjectDto projectDto)
        {
            var userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            projectDto.ProjectManagerID = userID;
            if (ModelState.IsValid)
            {
                projectRepository.InsertProject(projectDto);
                return RedirectToAction("ShowProjectManagerProjects");
            }
            else
                return RedirectToAction("Create");
        }

        [Authorize(Roles ="ProjectManager")]
        public IActionResult ShowProjectManagerProjects()
        {
            var projectManagerid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.projects = projectRepository.GetProjectManagerProjects(projectManagerid);
            return View();
        }

        [Authorize(Roles ="TeamLeader")]
        public IActionResult ShowTeamLeaderProjects()
        {
            var teamLeaderId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.projects = projectRepository.GetTeamLeaderProjects(teamLeaderId);
            return View();
        }

        [Authorize(Roles = "Developer")]
        public IActionResult ShowDeveloperProjects()
        {
            var developerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.projects = projectRepository.GetDevloperProjects(developerId);
            return View();
        }

        [Authorize(Roles = "ProjectManager")]
        public IActionResult ShowEditProject(int projectId)
        {
            var project = projectRepository.GetProject(projectId);
            var projectDevelopers = project.ProjectsDevelopers.Select(x => x.Developer).ToList();
            var developers = developerRepository.GetDevelopers();
            var teamLeaders = teamLeaderRepository.GetTeamLeaders();
            List<string> Ids = new List<string>();
            foreach (var developer in project.ProjectsDevelopers)
            {
                developers.Remove(developer.Developer);
            }
            foreach(var developer in project.ProjectsDevelopers)
            {
                Ids.Add(developer.DeveloperID);
            }
            ViewBag.unselectedDevelopers = developers;
            ViewBag.selectedDevelopers = projectDevelopers;
            teamLeaders.Remove(project.TeamLeader);
            ViewBag.unselectedLeaders = teamLeaders;
            var projectDto = new EditProjectDto()
            {
                ID = project.ID,
                ProjectTitle = project.ProjectTitle,
                Description = project.Description,
                Status = project.Status,
                TeamLeader = project.TeamLeader,
                TeamLeaderID = project.TeamLeaderID,
                ProjectManagerID = project.ProjectManagerID,
                developersIds = Ids
            };
            return View("Edit",projectDto);
        }

        [Authorize(Roles = "ProjectManager")]
        public IActionResult ApplayEdit(EditProjectDto projectDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            projectDto.ProjectManagerID = userId;
            projectRepository.EditProject(projectDto);
            return RedirectToAction("ShowProjectManagerProjects");
        }

        [Authorize(Roles ="ProjectManager")]
        public IActionResult DeleteProject(int projectId)
        {
            projectRepository.DeleteProject(projectId);
            return RedirectToAction("ShowProjectManagerProjects");
        }


        public string SetStatuseToComplete(int projectId)
        {
            var status = projectRepository.EditProjectStatusToComplete(projectId);
            return JsonConvert.SerializeObject(status);
        }

        public string CheckProjectComplete(int projectId)
        {
            var status = projectRepository.CheckProjectComplete(projectId);
            return JsonConvert.SerializeObject(status);
        }
    }
}
