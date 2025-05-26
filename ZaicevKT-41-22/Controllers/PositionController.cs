using Microsoft.AspNetCore.Mvc;
using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using ZaicevAntonKt_41_22.Interfaces;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        // GET: api/positions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDto>>> GetAllPositionsAsync([FromQuery] PositionFilter filter)
        {
            var positions = await _positionService.GetPositionsAsync(filter);
            return Ok(positions);
        }

        // GET: api/positions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDto>> GetPositionByIdAsync(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position == null) return NotFound();
            return Ok(position);
        }

        // POST: api/positions
        [HttpPost]
        public async Task<ActionResult<int>> CreatePositionAsync([FromBody] PositionDto positionDto)
        {
            var positionId = await _positionService.CreatePositionAsync(positionDto);
            return CreatedAtAction(nameof(GetPositionByIdAsync), new { id = positionId }, positionDto);
        }

        // PUT: api/positions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePositionAsync(int id, [FromBody] PositionDto positionDto)
        {
            await _positionService.UpdatePositionAsync(id, positionDto);
            return NoContent();
        }

        // DELETE: api/positions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositionAsync(int id)
        {
            await _positionService.DeletePositionAsync(id);
            return NoContent();
        }
    }
}