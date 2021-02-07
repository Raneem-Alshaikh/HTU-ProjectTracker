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
    public class SprintController : Controller
    {
        private ISprintRepository sprintRepository;
        private static int _projectId;

        public SprintController(ISprintRepository sprintRepository)
        {
            this.sprintRepository = sprintRepository;
        }

        [Authorize(Roles ="TeamLeader")]
        public IActionResult Create()
        {
            return View();
        }
       
        [Authorize]
        public IActionResult ShowProjectSprints(int projectId)
        {
            ViewBag.sprints= sprintRepository.GetProjectSprints(projectId);
            _projectId = projectId;
            ViewBag.projectId = _projectId;
            return View();
        }
        
        [Authorize(Roles = "TeamLeader")]
        public IActionResult InsertSprint(CreateSprintDto sprintDto)
        {  
            if (ModelState.IsValid)
            {
                sprintDto.TeamLeaderID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                sprintDto.ProjectID = _projectId;
                sprintRepository.InsertSprint(sprintDto);
                return RedirectToAction("ShowProjectSprints", new { @projectId = _projectId });
            }
            else
                return View("Create");
            
        }

        public string CheckProjectSprintsComplete(int projectId)
        {
            var status = sprintRepository.CheckAllSprintComplete(projectId);
            return JsonConvert.SerializeObject(status);
        }

        public string SetStatuseToComplete(int sprintId)
        {
            var status = sprintRepository.EditSprintStatusToComplete(sprintId);
            return JsonConvert.SerializeObject(status);
        }

        public string CheckSprintComplete(int sprintId)
        {
            var status = sprintRepository.CheckSprintComplete(sprintId);
            return JsonConvert.SerializeObject(status);
        }

    }
}
