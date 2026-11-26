using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course course);
        Task<bool> UpdateAsync(int id, Course input);
        Task<bool> DeleteAsync(int id);
    }
}
