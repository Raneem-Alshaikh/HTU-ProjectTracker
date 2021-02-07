﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.DTO
{
    public class CreateProjectDto
    {
        public int ID { get; set; }
        //[Required]
        public string ProjectManagerID { get; set; }

        [Required]
        [Display(Name= "Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        public string Description { get; set; }

        public Status Status { get; set; }

        [Required]
        public string TeamLeaderID { get; set; }

        [Required]
        public List<string> developersIds { get; set; }

        public string developers { get; set; }
    }
}
