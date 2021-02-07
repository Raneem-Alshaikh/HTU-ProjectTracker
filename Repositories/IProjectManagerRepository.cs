using FinalProject.DTO;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IProjectManagerRepository
    {
        public Task InsertProjectManager(CreateUserDto projectManagerDto);
        public ProjectManager GetProjectManager(string projectManagerId);
        public void EditProjectManager(EditUserDto projectManagerDto);
        public List<ProjectManager> GetProjectManagers();
        public void DeleteProjectManager(string Id);

    }
}
