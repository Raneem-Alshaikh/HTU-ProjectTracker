using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.DTO
{
    public class EditWorkDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile workFile { get; set; }
    }
}
