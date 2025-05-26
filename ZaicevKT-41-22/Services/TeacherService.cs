using Microsoft.EntityFrameworkCore;
using ZaicevAntonKt_41_22.Database;
using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using ZaicevAntonKt_41_22.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZaicevAntonKt_41_22.Models;

namespace ZaicevAntonKt_41_22.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly PrepodDbContext _context;

        public TeacherService(PrepodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeacherDto>> GetTeachersAsync(TeacherFilter filter)
        {
            var query = _context.Teachers.AsQueryable();

            if (filter.DepartmentId.HasValue)
                query = query.Where(t => t.DepartmentId == filter.DepartmentId.Value);

            if (filter.AcademicDegreeId.HasValue)
                query = query.Where(t => t.AcademicDegreeId == filter.AcademicDegreeId.Value);

            if (filter.PositionId.HasValue)
                query = query.Where(t => t.PositionId == filter.PositionId.Value);

            return await query
                .Select(t => new TeacherDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    DepartmentId = t.DepartmentId,
                    AcademicDegreeId = t.AcademicDegreeId,
                    PositionId = t.PositionId
                })
                .ToListAsync();
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {
            return await _context.Teachers
                .Where(t => t.Id == id)
                .Select(t => new TeacherDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    DepartmentId = t.DepartmentId,
                    AcademicDegreeId = t.AcademicDegreeId,
                    PositionId = t.PositionId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateTeacherAsync(TeacherDto teacherDto)
        {
            var teacher = new Teacher
            {
                Name = teacherDto.Name,
                DepartmentId = teacherDto.DepartmentId,
                AcademicDegreeId = teacherDto.AcademicDegreeId,
                PositionId = teacherDto.PositionId
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return teacher.Id;
        }

        public async Task UpdateTeacherAsync(int id, TeacherDto teacherDto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return;

            teacher.Name = teacherDto.Name;
            teacher.DepartmentId = teacherDto.DepartmentId;
            teacher.AcademicDegreeId = teacherDto.AcademicDegreeId;
            teacher.PositionId = teacherDto.PositionId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }
    }
}