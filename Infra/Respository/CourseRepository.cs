using Core.Entities;
using Core.Respository;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Respository
{
    public class CourseRepository(AppDbContext db) : ICourseRepository
    {
        public Task<List<Course>> GetAllAsync() => db.Courses.ToListAsync();
        public async Task<Course?> GetByIdAsync(int id) => await db.Courses.FindAsync(id);
        public async Task<Course> CreateAsync(Course course)
        {
            try
            {
                db.Courses.Add(course);
                await db.SaveChangesAsync();
                return course;
            }
            catch (DbUpdateException ex)
            when (ex.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation })
            {
                throw new ArgumentException("A course with this title already exists.");
            }
        }
        public async Task UpdateAsync(Course course)
        { db.Courses.Update(course); await db.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id)
        {
            var course = await db.Courses.FindAsync(id); if (course is null) return false;
            db.Courses.Remove(course); await db.SaveChangesAsync(); return true;
        }
    }
}
