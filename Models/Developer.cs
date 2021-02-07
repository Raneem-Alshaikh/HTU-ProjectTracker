using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Developer:User
    {
        public List<ProjectsDevelopers> ProjectsDevelopers { get; set; }
        public List<SprintTask> Tasks { get; set; }
        public List<Work> Works { get; set; }

    }
}
