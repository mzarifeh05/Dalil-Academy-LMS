using Core.DTOs;
using Core.Entities;
using Core.Service;
using FluentValidation;
using Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService courseService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<CourseResponseDTO>>> GetAll()
        {
            return Ok(await courseService.GetAllAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseResponseDTO>> GetById(int id)
        {
            var course = await courseService.GetByIdAsync(id);
            if (course is null) return NotFound(); return Ok(course);
        }
        [HttpPost]
        public async Task<ActionResult<CourseResponseDTO>> Create(CreateCourseDTO dto)
        {
            var created = await courseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Course course)
        {
            await courseService.UpdateAsync(id, course);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await courseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
