using Core.DTOs;
using Core.Entities;

namespace Core.Mappings
{
    public static class CourseMapping
    {
        public static CourseResponseDTO ToDTO(this Course course)
        {
            return new CourseResponseDTO(course.Id, course.Title, course.Price, course.Instructor?.FullName);
        }
        public static Course ToEntity(this CreateCourseDTO dto)
        {
            return new Course {
                Title = dto.Title, 
                Price = dto.Price, 
                InstructorId = dto.InstructorId
            };
        }
    }
}
