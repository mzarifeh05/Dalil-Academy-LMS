using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ICourseService
    {
        Task<List<CourseResponseDTO>> GetAllAsync();
        Task<CourseResponseDTO?> GetByIdAsync(int id);
        Task<CourseResponseDTO> CreateAsync(CreateCourseDTO course);
        Task UpdateAsync(int id, Course input);
        Task DeleteAsync(int id);
    }
}
