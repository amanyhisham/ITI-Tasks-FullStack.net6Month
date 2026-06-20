namespace Lap3WebAPI.DTOs
{
    public class DepartmentDTO
    {
        public int DeptId { get; set; }
        public string? DeptName { get; set; }
        public string? DeptDesc { get; set; }
        public int StudentCount { get; set; }
    }
}