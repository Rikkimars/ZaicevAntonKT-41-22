using Microsoft.EntityFrameworkCore;
using ZaicevAntonKt_41_22.Database;
using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using ZaicevAntonKt_41_22.Interfaces;
using ZaicevAntonKt_41_22.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly PrepodDbContext _context;

        public DepartmentService(PrepodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(DepartmentFilter filter)
        {
            var query = _context.Departments.AsQueryable();

            if (filter.FoundationDateFrom.HasValue)
                query = query.Where(d => d.FoundationDate >= filter.FoundationDateFrom.Value);

            if (filter.FoundationDateTo.HasValue)
                query = query.Where(d => d.FoundationDate <= filter.FoundationDateTo.Value);

            if (filter.TeachersCountMin.HasValue)
                query = query.Where(d => d.Teachers.Count() >= filter.TeachersCountMin.Value);

            if (filter.TeachersCountMax.HasValue)
                query = query.Where(d => d.Teachers.Count() <= filter.TeachersCountMax.Value);

            return await query
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    FoundationDate = d.FoundationDate,
                    HeadOfDepartmentId = d.HeadOfDepartmentId
                })
                .ToListAsync();
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments
                .Where(d => d.Id == id)
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    FoundationDate = d.FoundationDate,
                    HeadOfDepartmentId = d.HeadOfDepartmentId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = new Department
            {
                Name = departmentDto.Name,
                FoundationDate = departmentDto.FoundationDate,
                HeadOfDepartmentId = departmentDto.HeadOfDepartmentId // int? → int? — корректно
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return department.Id;
        }

        public async Task UpdateDepartmentAsync(int id, DepartmentDto departmentDto)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return;

            department.Name = departmentDto.Name;
            department.FoundationDate = departmentDto.FoundationDate;
            department.HeadOfDepartmentId = departmentDto.HeadOfDepartmentId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}
