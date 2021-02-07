using FinalProject.DTO;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IProjectRepository
    {
        public void InsertProject(CreateProjectDto projectDto);
        public Project GetProject(int projectId);
        public bool EditProjectStatusToComplete(int projectId);
        public List<Project> GetProjectManagerProjects(string projectManagerId);
        public List<Project> GetTeamLeaderProjects(string teamLeaderId);
        public List<Project> GetDevloperProjects(string developerId);
        public bool CheckProjectComplete(int projectId);
        public List<CreateProjectDto> GetProjectManagerProjectsAPI(string projectManagerId);
        public void EditProject(EditProjectDto projectDto);
        public void DeleteProject(int projectId);
    }
}