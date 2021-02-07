using FinalProject.DTO;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface ITaskRepository
    {
        public void InsertTask(CreateTaskDto tasktDto);
        public SprintTask GetTask(int taskId);
        public List<SprintTask> GetSprintTasks(int sprintId);
        public int GettaskIdForwork(int taskId);
        //return All tasks from projectSprint that assign to specific developer
        public List<SprintTask> GetProjectTasks(int projectId, string developerId);
        public bool CheckAllTaskComplete(int sprintId);
        public bool CheckTaskComplete(int taskId);
        public bool EditTaskStatusToComplete(int taskId);
    }

}
