using FinalProject.DTO;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.Repositories
{
    public interface IWorkRepository
    {
        public void InsertWork(CreateWorkDto workDto);
        public List<Work> GetTaskWorks(int taskId);
        public Work GetWork(int workId);
        public bool EditWorkStatus(int workId,Status status,string notes="");
        //public void AddRejectedNotes(int workId, string notes);
        public void EditWork(Work workDto);
        public bool CheckAllWorkApproved(int taskId);
    }
}
