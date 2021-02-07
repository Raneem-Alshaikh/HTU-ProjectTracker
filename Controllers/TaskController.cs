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
    public class TaskController : Controller
    {
        private IDeveloperRepository developerRepository;
        private ITaskRepository taskRepository;
        private ISprintRepository sprintRepository;
        private static int _sprintId;
        public TaskController(IDeveloperRepository developerRepository, ITaskRepository taskRepository,ISprintRepository sprintRepository)
        {
            this.developerRepository = developerRepository;
            this.taskRepository = taskRepository;
            this.sprintRepository = sprintRepository;
        }
        [Authorize(Roles = "TeamLeader")]
        public IActionResult Create()
        {
            int projectId = sprintRepository.GetProjectIdForSprint(_sprintId);
            ViewBag.developers = developerRepository.GetProjectDevelopers(projectId);
            return View();
        }
        [Authorize]
        public IActionResult ShowSprintTasks(int sprintId)
        {
            ViewBag.tasks = taskRepository.GetSprintTasks(sprintId);
            _sprintId = sprintId;
            ViewBag.sprintId = _sprintId;
            return View();
        }

        [Authorize(Roles = "TeamLeader")]
        public IActionResult InsertTask(CreateTaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                taskDto.SprintID = _sprintId;
                taskRepository.InsertTask(taskDto);
                return RedirectToAction("ShowSprintTasks", new { @sprintId = _sprintId });
            }
            else
                return RedirectToAction("Create");
        }
        [Authorize]
        public IActionResult ShowProjectTasks(int projectId)
        {
            var developerId= User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.developerTasks = taskRepository.GetProjectTasks(projectId, developerId);
            return View();
        }

        public string CheckTaskComplete(int taskId)
        {
            var status = taskRepository.CheckTaskComplete(taskId);
            return JsonConvert.SerializeObject(status);
        }

        public string CheckSprintTasksComplete(int sprintId)
        {
            var status = taskRepository.CheckAllTaskComplete(sprintId);
            return JsonConvert.SerializeObject(status);
        }
        public string SetStatuseToComplete(int taskId)
        {
            var status = taskRepository.EditTaskStatusToComplete(taskId);
            return JsonConvert.SerializeObject(status);
        }
    }
}
