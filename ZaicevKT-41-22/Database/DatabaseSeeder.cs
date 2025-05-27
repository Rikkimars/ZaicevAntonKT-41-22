using ZaicevAntonKt_41_22.Models;
using ZaicevAntonKt_41_22.Database;

public static class DatabaseSeeder
{
    public static void Seed(PrepodDbContext context)
    {
        if (context.Teachers.Any()) return; // База уже заполнена

        // Учёные степени
        var degrees = new[]
        {
            new AcademicDegree { Name = "Кандидат наук" },
            new AcademicDegree { Name = "Доктор наук" }
        };
        context.AcademicDegrees.AddRange(degrees);
        context.SaveChanges();

        // Должности
        var positions = new[]
        {
            new Position { Name = "Профессор" },
            new Position { Name = "Доцент" },
            new Position { Name = "Ассистент" }
        };
        context.Positions.AddRange(positions);
        context.SaveChanges();

        // Кафедры
        var departments = new[]
        {
            new Department { Name = "Кафедра информатики", FoundationDate = new DateTime(2010, 1, 1) },
            new Department { Name = "Кафедра математики", FoundationDate = new DateTime(2012, 5, 1) },
            new Department { Name = "Кафедра физики", FoundationDate = new DateTime(2015, 9, 1) }
        };
        context.Departments.AddRange(departments);
        context.SaveChanges();

        // Преподаватели
        var teachers = new[]
        {
            new Teacher { Name = "Иванов И.И.", DepartmentId = departments[0].Id, AcademicDegreeId = degrees[0].Id, PositionId = positions[0].Id },
            new Teacher { Name = "Петров П.П.", DepartmentId = departments[0].Id, AcademicDegreeId = degrees[1].Id, PositionId = positions[1].Id },
            new Teacher { Name = "Смирнова О.О.", DepartmentId = departments[0].Id, AcademicDegreeId = degrees[0].Id, PositionId = positions[2].Id },

            new Teacher { Name = "Сидоров А.А.", DepartmentId = departments[1].Id, AcademicDegreeId = degrees[0].Id, PositionId = positions[1].Id },
            new Teacher { Name = "Кузнецова Н.Н.", DepartmentId = departments[1].Id, AcademicDegreeId = degrees[1].Id, PositionId = positions[0].Id },

            new Teacher { Name = "Волков Д.Д.", DepartmentId = departments[2].Id, AcademicDegreeId = degrees[1].Id, PositionId = positions[0].Id }
        };
        context.Teachers.AddRange(teachers);
        context.SaveChanges();

        // Назначим заведующих
        departments[0].HeadOfDepartmentId = teachers[0].Id;
        departments[1].HeadOfDepartmentId = teachers[3].Id;
        departments[2].HeadOfDepartmentId = teachers[5].Id;
        context.SaveChanges();

        // Дисциплины
        var disciplines = new[]
        {
            new Discipline { Name = "ООП" },
            new Discipline { Name = "Алгоритмы" },
            new Discipline { Name = "Сети" },
            new Discipline { Name = "Математический анализ" },
            new Discipline { Name = "Линейная алгебра" },
            new Discipline { Name = "Квантовая физика" },
            new Discipline { Name = "Оптика" }
        };
        context.Disciplines.AddRange(disciplines);
        context.SaveChanges();

        // Нагрузки
        var workloads = new[]
        {
            // Кафедра информатики
            new Workload { TeacherId = teachers[0].Id, DisciplineId = disciplines[0].Id, Hours = 40 },
            new Workload { TeacherId = teachers[0].Id, DisciplineId = disciplines[1].Id, Hours = 30 },
            new Workload { TeacherId = teachers[1].Id, DisciplineId = disciplines[2].Id, Hours = 20 },
            new Workload { TeacherId = teachers[2].Id, DisciplineId = disciplines[0].Id, Hours = 15 },

            // Кафедра математики
            new Workload { TeacherId = teachers[3].Id, DisciplineId = disciplines[3].Id, Hours = 60 },
            new Workload { TeacherId = teachers[4].Id, DisciplineId = disciplines[4].Id, Hours = 45 },

            // Кафедра физики
            new Workload { TeacherId = teachers[5].Id, DisciplineId = disciplines[5].Id, Hours = 50 },
            new Workload { TeacherId = teachers[5].Id, DisciplineId = disciplines[6].Id, Hours = 35 }
        };
        context.Workloads.AddRange(workloads);
        context.SaveChanges();
    }
}
