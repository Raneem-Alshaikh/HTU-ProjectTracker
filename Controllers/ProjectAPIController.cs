using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalProject.DTO;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinalProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProjectAPIController : ControllerBase
    {
        private ITeamLeaderRepository teamLeaderRepository;
        private IProjectRepository projectRepository;
        private IDeveloperRepository developerRepository;
        public ProjectAPIController(ITeamLeaderRepository teamLeaderRepository, IProjectRepository projectRepository, IDeveloperRepository developerRepository)
        {
            this.teamLeaderRepository = teamLeaderRepository;
            this.projectRepository = projectRepository;
            this.developerRepository = developerRepository;
        }


        [HttpPost]
        public IActionResult InsertProject(CreateProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                projectRepository.InsertProject(projectDto);
            }
            return Ok();

        }

        [HttpGet("{projectManamgerId}")]
        public IActionResult ShowProjectManagerProjects(string projectManagerId)
        {
            try
            {
                var projects = projectRepository.GetProjectManagerProjectsAPI(projectManagerId);
                return new JsonResult(projects);
            }
            catch (Exception e)
            {
                return BadRequest("Invalid data.");
            }
        }

        [HttpPut("{projectId}")]
        public IActionResult SetStatuseToComplete(int projectId)
        {
            try
            {
                var status = projectRepository.EditProjectStatusToComplete(projectId);
                if (status)
                {
                    return Ok();
                }
                return BadRequest("Invalid!");
            }
            catch (Exception e)
            {
                return BadRequest("Invalid data.");
            }
        }
    
        [HttpGet("{projectId}")]
        public IActionResult CheckProjectComplete(int projectId)
        {
            try
            {
                var status = projectRepository.CheckProjectComplete(projectId);
                if (status)
                {
                    return Ok();
                }
                return BadRequest("Invalid!");
            }
            catch (Exception)
            {
                return BadRequest("Invalid data.");
            }
        }
        
        [HttpPut("{projectId}")]
        public IActionResult EditProject(int projectId,[FromBody] EditProjectDto projectDto)
        {
            try
            {
                projectRepository.EditProject(projectDto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Invalid data.");
            }
        }

        [HttpDelete("{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            try
            {
                projectRepository.DeleteProject(projectId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Invalid data.");
            }
        }
    }
}
