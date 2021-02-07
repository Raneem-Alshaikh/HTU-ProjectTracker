using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.DTO;
using FinalProject.Models;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class TeamLeaderController : Controller
    {
        private ITeamLeaderRepository teamLeaderRepository;

        public TeamLeaderController(ITeamLeaderRepository teamLeaderRepository)
        {
            this.teamLeaderRepository = teamLeaderRepository;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> InsertTeamLeader(CreateUserDto teamLeaderDto)
        {
            if (ModelState.IsValid)
            {
                await teamLeaderRepository.InsertTeamLeader(teamLeaderDto);
                return RedirectToAction("ShowTeamLeaders");
            }
            else
                return View("Create");
            
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ShowTeamLeaders()
        {
            ViewBag.TeamLeaders = teamLeaderRepository.GetTeamLeaders();
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTeamLeader(string Id)
        {
            teamLeaderRepository.DeleteTeamLeader(Id);
            return RedirectToAction("ShowTeamLeaders");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ShowEditTeamLeader(string teamLeaderId)
        {
            var teamLeader = teamLeaderRepository.GetTeamLeader(teamLeaderId);
            EditUserDto teamLeaderDto = new EditUserDto()
            {
                Id = teamLeader.Id,
                FirstName = teamLeader.FirstName,
                LastName = teamLeader.LastName,
                Email = teamLeader.Email,
                Age = teamLeader.Age
            };
            return View("Edit", teamLeaderDto);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ApplayEdit(EditUserDto teamLeaderDto)
        {
            if (ModelState.IsValid)
            {
                teamLeaderRepository.EditTeamLeader(teamLeaderDto);
                return RedirectToAction("ShowTeamLeaders");
            }
            else
                return View("Edit");
        }
    }
}
