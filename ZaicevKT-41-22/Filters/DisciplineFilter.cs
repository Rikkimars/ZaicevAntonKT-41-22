namespace ZaicevAntonKt_41_22.Filters
{
    public class DisciplineFilter
    {
        public string? Name { get; set; } // По названию дисциплины
        public int? TeacherId { get; set; } // По преподавателю
        public int? HoursMin { get; set; } // Минимум часов
        public int? HoursMax { get; set; } // Максимум часов
    }
}