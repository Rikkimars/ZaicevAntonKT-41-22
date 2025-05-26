using Microsoft.AspNetCore.Mvc;
using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using ZaicevAntonKt_41_22.Interfaces;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkloadsController : ControllerBase
    {
        private readonly IWorkloadService _workloadService;

        public WorkloadsController(IWorkloadService workloadService)
        {
            _workloadService = workloadService;
        }

        // GET: api/workloads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkloadDto>>> GetAllWorkloadsAsync([FromQuery] WorkloadFilter filter)
        {
            var workloads = await _workloadService.GetWorkloadsAsync(filter);
            return Ok(workloads);
        }

        // GET: api/workloads/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkloadDto>> GetWorkloadByIdAsync(int id)
        {
            var workload = await _workloadService.GetWorkloadByIdAsync(id);
            if (workload == null) return NotFound();
            return Ok(workload);
        }

        // POST: api/workloads
        [HttpPost]
        public async Task<ActionResult<int>> CreateWorkloadAsync([FromBody] WorkloadDto workloadDto)
        {
            var workloadId = await _workloadService.CreateWorkloadAsync(workloadDto);
            return CreatedAtAction(nameof(GetWorkloadByIdAsync), new { id = workloadId }, workloadDto);
        }

        // PUT: api/workloads/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkloadAsync(int id, [FromBody] WorkloadDto workloadDto)
        {
            await _workloadService.UpdateWorkloadAsync(id, workloadDto);
            return NoContent();
        }

        // DELETE: api/workloads/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkloadAsync(int id)
        {
            await _workloadService.DeleteWorkloadAsync(id);
            return NoContent();
        }
    }
}