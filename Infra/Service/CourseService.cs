using Core.Entities;
using Core.Respository;
using Core.Service;
using Infra.Respository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class CourseService(ICourseRepository courseRepository) : ICourseService
    {
        public Task<List<Course>> GetAllAsync() => courseRepository.GetAllAsync();
        public Task<Course?> GetByIdAsync(int id) => courseRepository.GetByIdAsync(id);
        public Task<Course> CreateAsync(Course course) => courseRepository.CreateAsync(course);
        public async Task<bool> UpdateAsync(int id, Course input)
        {
            var course = await courseRepository.GetByIdAsync(id);
            if (course is null) return false;
            course.Title = input.Title;
            course.Price = input.Price;
            await courseRepository.UpdateAsync(course); // EF sends UPDATE
            return true;
        }
        public async Task<bool> DeleteAsync(int id) => await courseRepository.DeleteAsync(id);
    }
}
