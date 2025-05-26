using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Interfaces
{
    public interface IAcademicDegreeService
    {
        Task<IEnumerable<AcademicDegreeDto>> GetAcademicDegreesAsync(AcademicDegreeFilter filter);
        Task<AcademicDegreeDto> GetAcademicDegreeByIdAsync(int id);
        Task<int> CreateAcademicDegreeAsync(AcademicDegreeDto academicDegreeDto);
        Task UpdateAcademicDegreeAsync(int id, AcademicDegreeDto academicDegreeDto);
        Task DeleteAcademicDegreeAsync(int id);
    }
}