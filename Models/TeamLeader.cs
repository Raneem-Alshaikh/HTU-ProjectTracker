using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class TeamLeader:User
    {
        public List<Project> Projects { get; set; }
        public List<Sprint> Sprints { get; set; }
        public List<SprintTask> Tasks { get; set; }

    }
}
