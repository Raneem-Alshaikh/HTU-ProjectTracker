using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.Models
{
    public class Work
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }//enum
        public int TaskId { get; set; }
        public SprintTask Task { get; set; }
        public string DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public Byte[] workFile { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string RejectedNotes { get; set; }

    }
}
