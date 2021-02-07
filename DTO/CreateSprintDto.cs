using FinalProject.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.DTO
{
    public class CreateSprintDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [CheckPastDate(ErrorMessage = "Date cannot be in the past!")]
        [Display(Name= "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [CheckPastDate(ErrorMessage = "Date cannot be in the past!")]
        [IsEndDateLessThanStartDate(otherPropertyName = "StartDate", ErrorMessage = "End date must be greater than start date")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required] 
        public string Description { get; set; }
        public Status Status { get; set; }//enum
        //[Required]
        public string TeamLeaderID { get; set; }
        //[Required]
        public int ProjectID { get; set; }
    }
}
