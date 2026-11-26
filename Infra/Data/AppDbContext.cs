using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Finds every IEntityTypeConfiguration<T> in this project
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSeeding((context, _) =>
            {
                if (context.Set<Instructor>().Any()) return;
                var ahmad = new Instructor { FullName = "Ahmad Ali" };
                var raghad = new Instructor { FullName = "Raghad Amjad" };

                context.Set<Course>().AddRange(
                    new Course { Title = "C# Fundementals", Price = 250, Instructor = ahmad},
                    new Course { Title = "ASP.NET Core Web API", Price = 500, Instructor = raghad}
                    );
                context.SaveChanges();
            });
        }
    }
}
