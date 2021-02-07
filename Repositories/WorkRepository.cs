using FinalProject.Data;
using FinalProject.DTO;
using FinalProject.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Models.HelperClass;

namespace FinalProject.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private ApplicationDbContext context;

        public WorkRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        //public void AddRejectedNotes(int workId, string notes)
        //{
        //    var work = context.Works.Find(workId);
        //    work.RejectedNotes = notes;
        //    context.Works.Update(work);
        //    context.SaveChanges();
        //}

        public bool CheckAllWorkApproved(int taskId)
        {
            List<Work> works = GetTaskWorks(taskId);
            if (works.Count > 0)
            {
                foreach (var work in works)
                {
                    if (work.Status != Status.Approved)
                        return false;
                }
                return true;
            }
            return false;
        }

        //public void EditWork(CreateWorkDto workDto)
        //{
        //    Work work = new Work()
        //    {
        //        ID=workDto.ID,
        //        DeveloperId = workDto.DeveloperId,
        //        Title = workDto.Title,
        //        Description = workDto.Description,
        //        Status = Status.PendingApproval,
        //        TaskId = workDto.TaskID
        //    };
        //    Stream stream = workDto.workFile.OpenReadStream();
        //    using (BinaryReader br = new BinaryReader(stream))
        //    {
        //        var byteFile = br.ReadBytes((int)stream.Length);
        //        work.FileName = workDto.workFile.FileName;
        //        work.FileType = workDto.workFile.ContentType;
        //        work.workFile = byteFile;
        //    }

        //    context.Works.Update(work);
        //    context.SaveChanges();
        //}

        public void EditWork(Work workDto)
        { 
            context.Works.Update(workDto);
            context.SaveChanges();
        }


        public bool EditWorkStatus(int workId,Status newStatus, string notes="")
        {
            try
            {
                var work = context.Works.Find(workId);
                work.Status = newStatus;
                if (newStatus == Status.Rejected)
                    work.RejectedNotes = notes;
                context.Works.Update(work);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception();
            }
            return true;
        }

        public List<Work> GetTaskWorks(int taskId)
        {
            var works = context.Works.Include(x=>x.Task).ThenInclude(x=>x.Sprint).Where(x => x.TaskId == taskId).ToList();
            return works;
        }

        public Work GetWork(int workId)
        {
            var work = context.Works.Where(x => x.ID == workId).SingleOrDefault();
            return work;
        }

        public void InsertWork(CreateWorkDto workDto)
        {
            Work work = new Work()
            {
                DeveloperId=workDto.DeveloperId,
                Title = workDto.Title,
                Description = workDto.Description,
                Status = Status.PendingApproval,
                TaskId = workDto.TaskID
            };
            Stream stream = workDto.workFile.OpenReadStream();
            using (BinaryReader br = new BinaryReader(stream))
            {
                var byteFile = br.ReadBytes((int)stream.Length);
                work.FileName = workDto.workFile.FileName;
                work.FileType = workDto.workFile.ContentType;
                work.workFile = byteFile;
            }

            context.Works.Add(work);
            context.SaveChanges();
        }
    }
}
