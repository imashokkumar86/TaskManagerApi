using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess
{
    public class ProjectManagerApiDbContext : DbContext
    {
        public ProjectManagerApiDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public virtual DbSet<TaskDetail> Tasks { get; set; }


        public virtual DbSet<ParentTaskDetails> ParentTask { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
            optionsBuilder.EnableSensitiveDataLogging();          
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
      builder.Entity<ParentTaskDetails>().HasKey("ParentId");
            builder.Entity<ParentTaskDetails>().ToTable("ParentTaskDetails");
            builder.Entity<ParentTaskDetails>().Property(p => p.ParentTask).HasColumnName("ParentTaskDetails").IsRequired().HasMaxLength(200);
      builder.Entity<ParentTaskDetails>().Property(t => t.ParentId).ValueGeneratedOnAdd().HasColumnName("Parent_Id").IsRequired();

      builder.Entity<TaskDetail>().HasKey("Id");
            builder.Entity<TaskDetail>().ToTable("Task");
            builder.Entity<TaskDetail>().Property(t => t.Name).HasColumnName("Task").IsRequired().HasMaxLength(100);
            builder.Entity<TaskDetail>().Property(t => t.StartDate).HasColumnName("Start_Date");
            builder.Entity<TaskDetail>().Property(t => t.EndDate).HasColumnName("End_Date");
            builder.Entity<TaskDetail>().Property(t => t.ParentId).HasColumnName("ParentId");
            builder.Entity<TaskDetail>().Property(t => t.Priority).IsRequired();
            builder.Entity<TaskDetail>().Property(t => t.ActiveStatus).HasColumnName("Status").IsRequired();
      builder.Entity<TaskDetail>().Property(t => t.Id).ValueGeneratedOnAdd().HasColumnName("Task_Id").IsRequired();

    }       
    }
}
