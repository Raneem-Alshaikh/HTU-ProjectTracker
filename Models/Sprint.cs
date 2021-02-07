using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.Models
{
    public class Sprint
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }//enum
        public string TeamLeaderID { get; set; }
        public TeamLeader TeamLeader { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public List<SprintTask> Tasks { get; set; }
    }
}
