using FinalProject.Models;
using FinalProject.Validation;
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
        [CheckPastDate(ErrorMessage = "Date cannot be in the past!")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [CheckPastDate(ErrorMessage = "Date cannot be in the past!")]
        [IsEndDateLessThanStartDate(otherPropertyName = "StartDate", ErrorMessage = "End date must be greater than start date")]
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
