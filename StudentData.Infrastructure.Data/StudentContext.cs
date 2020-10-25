using Microsoft.EntityFrameworkCore;
using System;
using StudentData.Domain.Core;

namespace StudentData.Infrastructure.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentGroup>()
                .HasKey(t => new { t.StudentId, t.GroupId });

            modelBuilder.Entity<StudentGroup>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentGroups)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentGroup>()
                .HasOne(sc => sc.Group)
                .WithMany(c => c.StudentGroups)
                .HasForeignKey(sc => sc.GroupId);
        }
    }
}
