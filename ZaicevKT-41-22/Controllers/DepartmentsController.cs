using Microsoft.AspNetCore.Mvc;
using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using ZaicevAntonKt_41_22.Interfaces;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAllDepartmentsAsync([FromQuery] DepartmentFilter filter)
        {
            var departments = await _departmentService.GetDepartmentsAsync(filter);
            return Ok(departments);
        }

        // GET: api/departments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        // POST: api/departments
        [HttpPost]
        public async Task<ActionResult<int>> CreateDepartmentAsync([FromBody] DepartmentDto departmentDto)
        {
            var departmentId = await _departmentService.CreateDepartmentAsync(departmentDto);
            return CreatedAtAction(nameof(GetDepartmentByIdAsync), new { id = departmentId }, departmentDto);
        }

        // PUT: api/departments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartmentAsync(int id, [FromBody] DepartmentDto departmentDto)
        {
            await _departmentService.UpdateDepartmentAsync(id, departmentDto);
            return NoContent();
        }

        // DELETE: api/departments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentAsync(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return NoContent();
        }
    }
}