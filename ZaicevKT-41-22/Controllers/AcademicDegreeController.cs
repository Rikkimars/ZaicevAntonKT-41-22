using Microsoft.AspNetCore.Mvc;
using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using ZaicevAntonKt_41_22.Interfaces;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicDegreesController : ControllerBase
    {
        private readonly IAcademicDegreeService _academicDegreeService;

        public AcademicDegreesController(IAcademicDegreeService academicDegreeService)
        {
            _academicDegreeService = academicDegreeService;
        }

        // GET: api/academicdegrees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicDegreeDto>>> GetAllAcademicDegreesAsync([FromQuery] AcademicDegreeFilter filter)
        {
            var degrees = await _academicDegreeService.GetAcademicDegreesAsync(filter);
            return Ok(degrees);
        }

        // GET: api/academicdegrees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicDegreeDto>> GetAcademicDegreeByIdAsync(int id)
        {
            var degree = await _academicDegreeService.GetAcademicDegreeByIdAsync(id);
            if (degree == null) return NotFound();
            return Ok(degree);
        }

        // POST: api/academicdegrees
        [HttpPost]
        public async Task<ActionResult<int>> CreateAcademicDegreeAsync([FromBody] AcademicDegreeDto academicDegreeDto)
        {
            var degreeId = await _academicDegreeService.CreateAcademicDegreeAsync(academicDegreeDto);
            return CreatedAtAction(nameof(GetAcademicDegreeByIdAsync), new { id = degreeId }, academicDegreeDto);
        }

        // PUT: api/academicdegrees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAcademicDegreeAsync(int id, [FromBody] AcademicDegreeDto academicDegreeDto)
        {
            await _academicDegreeService.UpdateAcademicDegreeAsync(id, academicDegreeDto);
            return NoContent();
        }

        // DELETE: api/academicdegrees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicDegreeAsync(int id)
        {
            await _academicDegreeService.DeleteAcademicDegreeAsync(id);
            return NoContent();
        }
    }
}