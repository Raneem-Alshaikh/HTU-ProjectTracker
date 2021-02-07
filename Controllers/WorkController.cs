using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalProject.DTO;
using FinalProject.Models;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static FinalProject.Models.HelperClass;

namespace FinalProject.Controllers
{
    public class WorkController : Controller
    {
        private IDeveloperRepository developerRepository;
        private ITaskRepository taskRepository;
        private ISprintRepository sprintRepository;
        private IWorkRepository workRepository;
        private static int _taskId;

        public WorkController(IDeveloperRepository developerRepository, ITaskRepository taskRepository, ISprintRepository sprintRepository, IWorkRepository workRepository)
        {
            this.developerRepository = developerRepository;
            this.taskRepository = taskRepository;
            this.sprintRepository = sprintRepository;
            this.workRepository = workRepository;
        }

        [Authorize(Roles = "Developer")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        public IActionResult ShowTaskWorks(int taskId)
        {
            var works = workRepository.GetTaskWorks(taskId);
            ViewBag.works = works;
            _taskId = taskId;
            ViewBag.taskId = _taskId;
            
            return View();
        }
        [Authorize(Roles = "Developer")]
        public IActionResult InsertWork(CreateWorkDto workDto)
        {
            if (ModelState.IsValid)
            {
                workDto.TaskID = _taskId;
                workDto.DeveloperId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                workRepository.InsertWork(workDto);
                return RedirectToAction("ShowTaskWorks", new { @taskId = _taskId });
            }
            else
                return View("Create");
        }
        [Authorize]
        public FileStreamResult GetFile(int workId)
        {
            var work = workRepository.GetWork(workId);
            Stream stream = new MemoryStream(work.workFile);
            return new FileStreamResult(stream, work.FileType);
        }
        [Authorize(Roles = "TeamLeader")]
        public IActionResult ApproveWork(int workId)
        {
            workRepository.EditWorkStatus(workId,Status.Approved);
            return RedirectToAction("ShowTaskWorks", new { @taskId = _taskId });
        }
        [Authorize(Roles = "TeamLeader")]
        public string RejectWork(int workId,string notes)
        {
            var status=workRepository.EditWorkStatus(workId, Status.Rejected,notes);

            RedirectToAction("ShowTaskWorks", new { @taskId = _taskId });
            return JsonConvert.SerializeObject(status);
        }

        //public void AddRejectedNotes(int workId, string notes)
        //{
        //    workRepository.AddRejectedNotes(workId, notes);
        //}
        [Authorize(Roles = "Developer")]
        public IActionResult EditWork(int workId)
        {
            var work = workRepository.GetWork(workId);
            return View(work);
        }
        [Authorize(Roles = "Developer")]
        public IActionResult ApplayEdit(Work workDto)
        {
            workRepository.EditWork(workDto);
            return RedirectToAction("ShowTaskWorks", new { @taskId = _taskId });
        }
        [Authorize]
        public string getWork(int workId)
        {
            var work = workRepository.GetWork(workId);
            return JsonConvert.SerializeObject(work);
        }

        public string CheckAllWorksApproved(int taskId)
        {
            if (taskId == 0)
                taskId = _taskId;
            var status = workRepository.CheckAllWorkApproved(taskId);
            //RedirectToAction("SetStatuseToComplete", "Task"); 
            return JsonConvert.SerializeObject(status); 
        }
    }
}
