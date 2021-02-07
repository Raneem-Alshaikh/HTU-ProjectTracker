using FinalProject.Data;
using FinalProject.DTO;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.Repositories
{
    public class ProjectRopository : IProjectRepository
    {
        private ApplicationDbContext context;

        public ProjectRopository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void InsertProject(CreateProjectDto projectDto)
        {
            Project project = new Project()
            {
                ProjectManagerID=projectDto.ProjectManagerID,
                ProjectTitle = projectDto.ProjectTitle,
                Description = projectDto.Description,
                Status = Status.PendingApproval,
                TeamLeaderID = projectDto.TeamLeaderID
            };
            context.Projects.Add(project);
            context.SaveChanges();

            foreach (var develioperId in projectDto.developersIds)
            {
                context.ProjectsDevelopers.Add(new ProjectsDevelopers()
                {
                    DeveloperID = develioperId,
                    ProjectID = project.ID
                });

            }
            context.SaveChanges();

        }

        public List<Project> GetProjectManagerProjects(string projectManagerId)
        { 
            var projects= context.Projects.Include(x=>x.TeamLeader).Where(x => x.ProjectManagerID == projectManagerId).Include(x=>x.ProjectsDevelopers).ThenInclude(x=>x.Developer).ToList();
            return projects;
        }

        public List<CreateProjectDto> GetProjectManagerProjectsAPI(string projectManagerId)
        {
            List<CreateProjectDto> projectDtos = new List<CreateProjectDto>();
            var projects = context.Projects.Include(x => x.TeamLeader).Where(x => x.ProjectManagerID == projectManagerId).Include(x => x.ProjectsDevelopers).ThenInclude(x => x.Developer).ToList();
            foreach (var project in projects)
            {
                projectDtos.Add(new CreateProjectDto()
                {
                    ProjectManagerID=projectManagerId,
                    ProjectTitle=project.ProjectTitle,
                    Description=project.Description,
                    Status=project.Status,
                    TeamLeaderID=project.TeamLeader.FirstName+project.TeamLeader.LastName,
                    developers = string.Join('-', project.ProjectsDevelopers.Select(x => x.Developer.FirstName).ToList())
                });
            }
            return projectDtos;
            
        }

        public List<Project> GetTeamLeaderProjects(string teamLeaderId)
        {
            var projects = context.Projects.Include(x => x.ProjectsDevelopers).ThenInclude(x=>x.Developer).Where(x => x.TeamLeaderID == teamLeaderId).Include(x=>x.projectManager).ToList();
            return projects;
        }

        public List<Project> GetDevloperProjects(string developerId)
        {
            var projects = context.ProjectsDevelopers.Include(x => x.Project).ThenInclude(x=>x.TeamLeader).Where(x => x.DeveloperID == developerId).Select(x => x.Project).ToList();
            return projects;
        }

        public Project GetProject(int projectId)
        {
            var project = context.Projects.Include(x=>x.ProjectsDevelopers).ThenInclude(x=>x.Developer)
                .Where(x => x.ID == projectId).Include(x=>x.TeamLeader).SingleOrDefault();
            return project;
        }

        public bool EditProjectStatusToComplete(int projectId)
        {
            try
            {
                var project = GetProject(projectId);
                project.Status = Status.Complete;
                context.Projects.Update(project);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return true;
        }

        public bool CheckProjectComplete(int projectId)
        {
            var project = GetProject(projectId);
            return (project.Status == Status.Complete);
        }


        public void EditProject(EditProjectDto projectDto)
        {
            var project = GetProject(projectDto.ID);
            project.ProjectTitle = projectDto.ProjectTitle;
            project.Description = projectDto.Description;
            project.TeamLeaderID = projectDto.TeamLeaderID;
            project.ProjectManagerID = projectDto.ProjectManagerID;
            foreach (var projectDeveloper in project.ProjectsDevelopers)
            {
                context.ProjectsDevelopers.Remove(projectDeveloper);

            }
            context.SaveChanges();
            foreach (var developerId in projectDto.developersIds)
            {
                context.ProjectsDevelopers.Add(new ProjectsDevelopers()
                {
                    DeveloperID=developerId,
                    ProjectID=project.ID
                });

            }
            context.SaveChanges();
            context.Projects.Update(project);
            context.SaveChanges();
        }


        public void DeleteProject(int projectId)
        {
            var project = GetProject(projectId);
            context.Projects.Remove(project);
            context.SaveChanges();
        }
    }
}
