using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ZaicevKT_41_22.Tests
{
    public class DisciplineServiceTests
    {
        public class TestDbContext : DbContext
        {
            public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

            public DbSet<Discipline> Disciplines { get; set; }
        }

        public class Discipline
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class DisciplineService
        {
            private readonly TestDbContext _context;

            public DisciplineService(TestDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Discipline>> GetAllAsync()
            {
                return await _context.Disciplines.ToListAsync();
            }
        }

        [Fact]
        public async Task GetAllDisciplines_ReturnsCorrectCount()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase("DisciplinesTestDb")
                .Options;

            using var context = new TestDbContext(options);
            context.Disciplines.AddRange(
                new Discipline { Name = "Математика" },
                new Discipline { Name = "Программирование" },
                new Discipline { Name = "Физика" }
            );
            await context.SaveChangesAsync();

            var service = new DisciplineService(context);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.Equal(3, result.Count());
        }
    }
}
