using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.DTO
{
    public class CreateTaskDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Status Status { get; set; }//enum
        [Required]
        public int SprintID { get; set; }
        [Required]
        public string DeveloperId { get; set; }

    }
}
