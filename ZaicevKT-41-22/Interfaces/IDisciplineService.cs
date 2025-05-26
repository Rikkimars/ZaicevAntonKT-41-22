using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Interfaces
{
    public interface IDisciplineService
    {
        Task<IEnumerable<DisciplineDto>> GetDisciplinesAsync(DisciplineFilter filter);
        Task<DisciplineDto> GetDisciplineByIdAsync(int id);
        Task<int> CreateDisciplineAsync(DisciplineDto disciplineDto);
        Task UpdateDisciplineAsync(int id, DisciplineDto disciplineDto);
        Task DeleteDisciplineAsync(int id);
    }
}