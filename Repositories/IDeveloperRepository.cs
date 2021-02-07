using FinalProject.DTO;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IDeveloperRepository
    {
        public Task InsertDeveloper(CreateUserDto developerDto);
        public List<Developer> GetDevelopers();
        public Developer GetDeveloper(string developerId);
        public List<Developer> GetProjectDevelopers(int projectId);
        public void DeleteDeveloper(string Id);
        public void EditDeveloper(EditUserDto developerDto);
    }
}
