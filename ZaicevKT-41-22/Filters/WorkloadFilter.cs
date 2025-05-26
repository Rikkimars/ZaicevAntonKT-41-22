namespace ZaicevAntonKt_41_22.Filters
{
    public class WorkloadFilter
    {
        public int? TeacherId { get; set; } // По преподавателю
        public int? DepartmentId { get; set; } // По кафедре
        public int? DisciplineId { get; set; } // По дисциплине
    }
}