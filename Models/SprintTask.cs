using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.Models
{
    public class SprintTask
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DeveloperID { get; set; }
        public Developer Developer { get; set; }
        public int SprintID { get; set; }
        public Sprint Sprint { get; set; }
        public List<Work> Works { get; set; }

    }
}
