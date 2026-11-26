using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public record CreateCourseDTO(string Title, decimal Price, int InstructorId);
    public record UpdateCourseDTO(string Title, decimal Price);
    public record CourseResponseDTO(int Id, string Title, decimal Price, string? InstructorName);

}
