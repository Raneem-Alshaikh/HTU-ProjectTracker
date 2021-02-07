using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.DTO
{
    public class CreateWorkDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }//enum
        public int TaskID { get; set; }
        public string DeveloperId { get; set; }
        public IFormFile workFile { get; set; }
        
    }
}
