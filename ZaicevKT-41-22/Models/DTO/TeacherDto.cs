namespace ZaicevAntonKt_41_22.DTO
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? DepartmentId { get; set; }
        public int AcademicDegreeId { get; set; }
        public int PositionId { get; set; }
    }
}