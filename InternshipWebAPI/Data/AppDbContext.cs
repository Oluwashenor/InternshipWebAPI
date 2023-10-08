using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InternshipWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProgramTemplate> ProgramTemplates { get; set; }
        public DbSet<ApplicationFormTemplate> ApplicationFormTemplates { get; set; }
        public DbSet<Workflow> Workflows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProgramTemplate>()
            //.HasOne(p => p.ApplicationTemplate)
            //.WithMany()
            //.HasForeignKey(p => p.ApplicationTemplateId);
            //modelBuilder.Entity<ProgramTemplate>().ToContainer("Programs");
            //modelBuilder.Entity<ProgramTemplate>().HasKey("Id");
            //modelBuilder.Entity<ProgramTemplate>().HasPartitionKey("key");
            base.OnModelCreating(modelBuilder);
        }
    }
}
