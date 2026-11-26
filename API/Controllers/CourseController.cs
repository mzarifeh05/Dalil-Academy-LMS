using Core.Entities;
using Core.Service;
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
        public async Task<ActionResult<List<Course>>> GetAll() => Ok(await courseService.GetAllAsync());
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await courseService.GetByIdAsync(id);
            if (course is null) return NotFound(); return Ok(course);
        }
        [HttpPost]
        public async Task<ActionResult<Course>> Create(Course course)
        {
            try
            {
                var created = await courseService.CreateAsync(course);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Course course)
        {
            try { return await courseService.UpdateAsync(id, course) ? NoContent() : NotFound(); }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        => await courseService.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
