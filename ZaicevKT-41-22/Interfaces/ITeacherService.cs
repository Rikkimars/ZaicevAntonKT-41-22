using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetTeachersAsync(TeacherFilter filter);
        Task<TeacherDto> GetTeacherByIdAsync(int id);
        Task<int> CreateTeacherAsync(TeacherDto teacherDto);
        Task UpdateTeacherAsync(int id, TeacherDto teacherDto);
        Task DeleteTeacherAsync(int id);
    }
}