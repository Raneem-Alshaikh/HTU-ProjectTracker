using FinalProject.Data;
using FinalProject.DTO;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class DeveloperRepository:IDeveloperRepository
    {
        private ApplicationDbContext context;
        private UserManager<IdentityUser> userManager;

        public DeveloperRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }


        public List<Developer> GetDevelopers()
        {
            return context.Developers.ToList();
        }

        public List<Developer> GetProjectDevelopers(int projectId)
        {
            var developers = context.ProjectsDevelopers.Include(x => x.Developer).Where(x => x.ProjectID == projectId).Select(x => x.Developer).ToList();
            return developers;
        }
        public async Task InsertDeveloper(CreateUserDto developerDto)
        {
            Developer developer = new Developer()
            {
                FirstName = developerDto.FirstName,
                LastName = developerDto.LastName,
                Age = developerDto.Age,
                Email = developerDto.Email,
                UserName = developerDto.Email,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(developer, developerDto.Password);
            if (result.Succeeded)
            {
                context.UserRoles.Add(new IdentityUserRole<string>
                {
                    RoleId = "4",
                    UserId = developer.Id
                });
                context.SaveChanges();

            }
        }

        public void DeleteDeveloper(string Id)
        {
            context.Developers.Remove(context.Developers.Find(Id));
            context.SaveChanges();
        }

        public Developer GetDeveloper(string developerId)
        {
            var developer = context.Developers.Where(x => x.Id == developerId).SingleOrDefault();
            return developer;
        }

        public void EditDeveloper(EditUserDto developerDto)
        {
            var developer = GetDeveloper(developerDto.Id);
            developer.FirstName = developerDto.FirstName;
            developer.LastName = developerDto.LastName;
            developer.Age = developerDto.Age;
            developer.Email = developerDto.Email;

            context.Developers.Update(developer);
            context.SaveChanges();

        }
    }
}
