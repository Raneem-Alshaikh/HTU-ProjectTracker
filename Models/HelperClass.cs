using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class HelperClass
    {
        public enum Status
        {
            Approved = 1,
            [Display(Name="Pending Approval")]
            PendingApproval = 2,
            Rejected = 3,
            Complete = 4
        }
        public enum Roles
        {
            ProjectManager = 1,
            TeamLeader = 2,
            Developer = 3
        }
    }
}
