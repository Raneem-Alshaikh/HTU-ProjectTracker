using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ProjectsDevelopers
    {
        public int ProjectID { get; set; }
        public string DeveloperID { get; set; }
        public Project Project { get; set; }
        public Developer Developer { get; set; }
    }
}
