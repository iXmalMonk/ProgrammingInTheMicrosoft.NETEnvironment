namespace Program.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Manager { get; set; }
        public string Name { get; set; }
        public int NumberOfTeachers { get; set; }
        public int FacultyId { get; set; }
    }
}
