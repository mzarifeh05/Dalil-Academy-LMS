using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Core.Mappings;
using Core.Respository;
using Core.Service;
using FluentValidation;
using Infra.Respository;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Infra.Service
{
    public class CourseService(ICourseRepository courseRepository, IValidator<CreateCourseDTO> validator) : ICourseService
    {
        public async Task<List<CourseResponseDTO>> GetAllAsync() 
        {
            var courses = await courseRepository.GetAllAsync();
            return courses.Select(c => c.ToDTO()).ToList();
        }
        public async Task<CourseResponseDTO?> GetByIdAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Course {id} was not found.");
            return course?.ToDTO();
        }
        public async Task<CourseResponseDTO> CreateAsync(CreateCourseDTO dto)
        {
            await validator.ValidateAndThrowAsync(dto);
            var course = dto.ToEntity();
            var created = await courseRepository.CreateAsync(course);
            return created.ToDTO();
        }
        public async Task UpdateAsync(int id, Course input)
        {
            var course = await courseRepository.GetByIdAsync(id);
            if (course is null) 
                throw new NotFoundException($"Course {id} was not found.");
            course.Title = input.Title;
            course.Price = input.Price;
            await courseRepository.UpdateAsync(course); // EF sends UPDATE
        }
        public async Task DeleteAsync(int id)
        {
            if (!await courseRepository.DeleteAsync(id))
                throw new NotFoundException($"Course {id} was not found.");
        }
    }
}
