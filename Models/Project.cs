using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string ProjectManagerID { get; set; }
        public ProjectManager projectManager { get; set; }
        public string TeamLeaderID { get; set; }
        public TeamLeader TeamLeader { get; set; }
        public List<ProjectsDevelopers> ProjectsDevelopers { get; set; }
        public List<Sprint> Sprints { get; set; }

    }
}
