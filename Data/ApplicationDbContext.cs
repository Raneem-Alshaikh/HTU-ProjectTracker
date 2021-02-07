using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectManager> ProjectManagers { get; set; }
        public virtual DbSet<TeamLeader> TeamLeaders { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public virtual DbSet<SprintTask> SprintTasks { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<ProjectsDevelopers> ProjectsDevelopers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProjectsDevelopers>().HasKey(x => new { x.DeveloperID, x.ProjectID });
            
        }
    }
}
