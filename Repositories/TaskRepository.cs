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
    public class TaskRepository : ITaskRepository
    {
        private ApplicationDbContext context;

        public TaskRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CheckAllTaskComplete(int sprintId)
        {
            
            List<SprintTask> tasks = GetSprintTasks(sprintId);
            if(tasks.Count > 0){
                foreach (var task in tasks)
                {
                    if (task.Status != Status.Complete)
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool CheckTaskComplete(int taskId)
        {
            var task = GetTask(taskId);
            return (task.Status == Status.Complete);
        }

        public bool EditTaskStatusToComplete(int taskId)
        {
            try
            {
                var task = GetTask(taskId);
                task.Status = Status.Complete;
                context.SprintTasks.Update(task);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception();
            }
            return true;
        }

        public List<SprintTask> GetProjectTasks(int projectId, string developerId)
        {
            var projectSprint = context.Sprints.Where(x => x.ProjectID == projectId).ToList();
            List<SprintTask> developerTasks = new List<SprintTask>(); ;
            foreach (var sprint in projectSprint)
            {
                var sprintTasks = GetSprintTasks(sprint.ID);
                if(sprintTasks!=null)
                    foreach (var sprintTask in sprintTasks)
                    {
                        if (sprintTask.DeveloperID == developerId)
                            developerTasks.Add(sprintTask);
                    } 
            }
            
            return developerTasks;
        }

        public List<SprintTask> GetSprintTasks(int sprintId)
        {
            var tasks=context.SprintTasks.Include(x => x.Developer).Where(x => x.SprintID == sprintId).Include(x=>x.Sprint).ToList();
            return tasks;
        }

        public SprintTask GetTask(int taskId)
        {
            var task = context.SprintTasks.Where(x => x.ID == taskId).SingleOrDefault();
            return task;
        }

        public int GettaskIdForwork(int workId)
        {
            var taskId = context.Works.Where(x => x.ID == workId).Select(x => x.TaskId).FirstOrDefault();
            return taskId;
        }

        public void InsertTask(CreateTaskDto tasktDto)
        {
            SprintTask task = new SprintTask()
            {
                SprintID = tasktDto.SprintID,
                Title = tasktDto.Title,
                Description = tasktDto.Description,
                Status = Status.PendingApproval,
                StartDate = tasktDto.StartDate,
                EndDate = tasktDto.EndDate,
                DeveloperID = tasktDto.DeveloperId

            };

            context.SprintTasks.Add(task);
            context.SaveChanges();
        }

       
    }
}
