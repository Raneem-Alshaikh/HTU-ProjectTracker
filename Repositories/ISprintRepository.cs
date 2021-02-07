using FinalProject.DTO;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface ISprintRepository
    {
        public void InsertSprint(CreateSprintDto sprinttDto);
        public Sprint GetSprint(int sprintId);
        public bool CheckAllSprintComplete(int projectId);
        public bool EditSprintStatusToComplete(int sprintId);
        public List<Sprint> GetProjectSprints(int projectId);
        public int GetProjectIdForSprint(int sprintId);
        public bool CheckSprintComplete(int sprintId);

    }
}
