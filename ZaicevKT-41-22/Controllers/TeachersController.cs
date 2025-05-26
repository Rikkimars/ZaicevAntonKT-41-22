using Microsoft.AspNetCore.Mvc;
using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using ZaicevAntonKt_41_22.Interfaces;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET: api/teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAllTeachersAsync([FromQuery] TeacherFilter filter)
        {
            var teachers = await _teacherService.GetTeachersAsync(filter);
            return Ok(teachers);
        }

        // GET: api/teachers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetTeacherByIdAsync(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        // POST: api/teachers
        [HttpPost]
        public async Task<ActionResult<int>> CreateTeacherAsync([FromBody] TeacherDto teacherDto)
        {
            var teacherId = await _teacherService.CreateTeacherAsync(teacherDto);
            return CreatedAtAction(nameof(GetTeacherByIdAsync), new { id = teacherId }, teacherDto);
        }

        // PUT: api/teachers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacherAsync(int id, [FromBody] TeacherDto teacherDto)
        {
            await _teacherService.UpdateTeacherAsync(id, teacherDto);
            return NoContent();
        }

        // DELETE: api/teachers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherAsync(int id)
        {
            await _teacherService.DeleteTeacherAsync(id);
            return NoContent();
        }
    }
}