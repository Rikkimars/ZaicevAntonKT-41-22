using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(DepartmentFilter filter);
        Task<DepartmentDto> GetDepartmentByIdAsync(int id);
        Task<int> CreateDepartmentAsync(DepartmentDto departmentDto);
        Task UpdateDepartmentAsync(int id, DepartmentDto departmentDto);
        Task DeleteDepartmentAsync(int id);
    }
}