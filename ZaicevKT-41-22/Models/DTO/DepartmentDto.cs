namespace ZaicevAntonKt_41_22.DTO
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime FoundationDate { get; set; }
        public int HeadOfDepartmentId { get; set; }
    }
}