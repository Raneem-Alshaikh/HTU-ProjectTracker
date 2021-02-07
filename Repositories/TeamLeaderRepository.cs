using FinalProject.Data;
using FinalProject.DTO;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class TeamLeaderRepository : ITeamLeaderRepository
    {
        private ApplicationDbContext context;
        private UserManager<IdentityUser> userManager;

        public TeamLeaderRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        
        public List<TeamLeader> GetTeamLeaders()
        {
            return context.TeamLeaders.ToList();
        }

        public async Task InsertTeamLeader(CreateUserDto teamLeaderDto)
        {
            TeamLeader teamLeader = new TeamLeader()
            {
                FirstName = teamLeaderDto.FirstName,
                LastName = teamLeaderDto.LastName,
                Age = teamLeaderDto.Age,
                Email = teamLeaderDto.Email,
                UserName = teamLeaderDto.Email,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(teamLeader,teamLeaderDto.Password);
            if (result.Succeeded)
            {
                context.UserRoles.Add(new IdentityUserRole<string>
                {
                    RoleId = "3",
                    UserId = teamLeader.Id
                });
                context.SaveChanges();

            }
        }

        public void DeleteTeamLeader(string Id)
        {
            context.TeamLeaders.Remove(context.TeamLeaders.Find(Id));
            context.SaveChanges();
        }

        public TeamLeader GetTeamLeader(string teamLeaderId)
        {
            var teamLeader = context.TeamLeaders.Find(teamLeaderId);
            return teamLeader;
        }

        public void EditTeamLeader(EditUserDto teamLeaderDto)
        {
            var teamLeader = GetTeamLeader(teamLeaderDto.Id);
            teamLeader.FirstName = teamLeaderDto.FirstName;
            teamLeader.LastName = teamLeaderDto.LastName;
            teamLeader.Age = teamLeaderDto.Age;
            teamLeader.Email = teamLeaderDto.Email;

            context.TeamLeaders.Update(teamLeader);
            context.SaveChanges();
        }
    }
}
