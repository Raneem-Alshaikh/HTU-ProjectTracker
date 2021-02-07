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
    public class ProjectManagerRopesitory : IProjectManagerRepository
    {
        private ApplicationDbContext context;
        private UserManager<IdentityUser> userManager;
        public ProjectManagerRopesitory(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            context = applicationDbContext;
            this.userManager = userManager;
        }

        public async Task InsertProjectManager(CreateUserDto projectManagerDto)
        {
            var projectManager = new ProjectManager()
            {
                FirstName = projectManagerDto.FirstName,
                LastName = projectManagerDto.LastName,
                Age = projectManagerDto.Age,
                Email = projectManagerDto.Email,
                UserName = projectManagerDto.Email,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(projectManager,projectManagerDto.Password);
            if (result.Succeeded)
            {
                context.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = projectManager.Id,
                    RoleId = "2"
                });

                context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public List<ProjectManager> GetProjectManagers()
        {
            return context.ProjectManagers.ToList();
        }

        public void DeleteProjectManager(string Id)
        {
            context.ProjectManagers.Remove(context.ProjectManagers.Find(Id));
            context.SaveChanges();
        }

        public ProjectManager GetProjectManager(string projectManagerId)
        {
            var projectManager = context.ProjectManagers.Find(projectManagerId);
            return projectManager;
        }

        public void EditProjectManager(EditUserDto projectManagerDto)
        {
            var projectManager = GetProjectManager(projectManagerDto.Id);
            projectManager.FirstName = projectManagerDto.FirstName;
            projectManager.LastName = projectManagerDto.LastName;
            projectManager.Age = projectManagerDto.Age;
            projectManager.Email = projectManagerDto.Email;

            context.ProjectManagers.Update(projectManager);
            context.SaveChanges();
        }
    }
}
