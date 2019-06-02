using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreApp.Models
{
    public class ResortContext : DbContext
    {
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ResortContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<StudentCourse>()
           //.HasKey(t => new { t.StudentId, t.CourseId });

           // modelBuilder.Entity<StudentCourse>()
           //     .HasOne(sc => sc.Student)
           //     .WithMany(s => s.StudentCourses)
           //     .HasForeignKey(sc => sc.StudentId);

           // modelBuilder.Entity<StudentCourse>()
           //     .HasOne(sc => sc.Course)
           //     .WithMany(c => c.StudentCourses)
           //     .HasForeignKey(sc => sc.CourseId);
        }
    }
}
