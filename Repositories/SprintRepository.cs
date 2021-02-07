using FinalProject.Data;
using FinalProject.DTO;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.Repositories
{
    public class SprintRepository : ISprintRepository
    {
        private ApplicationDbContext context;

        public SprintRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Sprint> GetProjectSprints(int projectId)
        {
            return context.Sprints.Include(x=>x.Project).Where(x => x.ProjectID == projectId).ToList();
        }

        public int GetProjectIdForSprint(int sprintId)
        {
            var projectId = context.Sprints.Where(x => x.ID == sprintId).Select(x => x.ProjectID).FirstOrDefault();
            return projectId;
        }
        
        public void InsertSprint(CreateSprintDto sprintDto)
        {
            
            Sprint sprint = new Sprint()
            {
                ProjectID = sprintDto.ProjectID,
                Title = sprintDto.Title,
                Description = sprintDto.Description,
                Status = Status.PendingApproval,
                StartDate = sprintDto.StartDate,
                EndDate = sprintDto.EndDate,
                TeamLeaderID = sprintDto.TeamLeaderID
            };

            context.Sprints.Add(sprint);
            context.SaveChanges();
        }

        public Sprint GetSprint(int sprintId)
        {
            var sprint = context.Sprints.Where(x => x.ID == sprintId).SingleOrDefault();
            return sprint;
        }

        public bool CheckAllSprintComplete(int projectId)
        {
            List<Sprint> sprints = GetProjectSprints(projectId);
            if (sprints.Count > 0)
            {
                foreach (var sprint in sprints)
                {
                    if (sprint.Status != Status.Complete)
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool EditSprintStatusToComplete(int sprintId)
        {
            try
            {
                var sprint = GetSprint(sprintId);
                sprint.Status = Status.Complete;
                context.Sprints.Update(sprint);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception();
            };
            return true;
        }

        public bool CheckSprintComplete(int sprintId)
        {
            var sprint = GetSprint(sprintId);
            return (sprint.Status == Status.Complete);
        }
    }
}
