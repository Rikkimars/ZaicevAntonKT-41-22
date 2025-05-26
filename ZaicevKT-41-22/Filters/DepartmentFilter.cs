namespace ZaicevAntonKt_41_22.Filters
{
    public class DepartmentFilter
    {
        public string? Name { get; set; } // Фильтр по названию кафедры
        public DateTime? FoundationDateFrom { get; set; } // Дата основания от
        public DateTime? FoundationDateTo { get; set; }   // Дата основания до
        public int? TeachersCountMin { get; set; } // Минимум преподавателей
        public int? TeachersCountMax { get; set; } // Максимум преподавателей
    }
}