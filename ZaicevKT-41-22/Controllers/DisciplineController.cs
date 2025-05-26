using Microsoft.AspNetCore.Mvc;
using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using ZaicevAntonKt_41_22.Interfaces;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplinesController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        // GET: api/disciplines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplineDto>>> GetAllDisciplinesAsync([FromQuery] DisciplineFilter filter)
        {
            var disciplines = await _disciplineService.GetDisciplinesAsync(filter);
            return Ok(disciplines);
        }

        // GET: api/disciplines/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplineDto>> GetDisciplineByIdAsync(int id)
        {
            var discipline = await _disciplineService.GetDisciplineByIdAsync(id);
            if (discipline == null) return NotFound();
            return Ok(discipline);
        }

        // POST: api/disciplines
        [HttpPost]
        public async Task<ActionResult<int>> CreateDisciplineAsync([FromBody] DisciplineDto disciplineDto)
        {
            var disciplineId = await _disciplineService.CreateDisciplineAsync(disciplineDto);
            return CreatedAtAction(nameof(GetDisciplineByIdAsync), new { id = disciplineId }, disciplineDto);
        }

        // PUT: api/disciplines/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDisciplineAsync(int id, [FromBody] DisciplineDto disciplineDto)
        {
            await _disciplineService.UpdateDisciplineAsync(id, disciplineDto);
            return NoContent();
        }

        // DELETE: api/disciplines/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplineAsync(int id)
        {
            await _disciplineService.DeleteDisciplineAsync(id);
            return NoContent();
        }
    }
}