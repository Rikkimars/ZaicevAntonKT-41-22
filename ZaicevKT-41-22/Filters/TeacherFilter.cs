namespace ZaicevAntonKt_41_22.Filters
{
    public class TeacherFilter
    {
        public string? Name { get; set; } // Фильтр по имени преподавателя
        public int? DepartmentId { get; set; } // По кафедре
        public int? AcademicDegreeId { get; set; } // По учёной степени
        public int? PositionId { get; set; } // По должности
    }
}