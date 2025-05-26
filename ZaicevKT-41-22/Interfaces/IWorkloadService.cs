using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Interfaces
{
    public interface IWorkloadService
    {
        Task<IEnumerable<WorkloadDto>> GetWorkloadsAsync(WorkloadFilter filter);
        Task<WorkloadDto> GetWorkloadByIdAsync(int id);
        Task<int> CreateWorkloadAsync(WorkloadDto workloadDto);
        Task UpdateWorkloadAsync(int id, WorkloadDto workloadDto);
        Task DeleteWorkloadAsync(int id);
    }
}