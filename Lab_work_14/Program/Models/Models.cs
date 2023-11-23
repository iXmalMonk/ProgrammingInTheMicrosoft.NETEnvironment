namespace Program.Models
{
    public class Models
    {
        public List<DepartmentModel> Department { get; set; }
        public List<FacultyModel> Faculty { get; set; }

        public Models(List<DepartmentModel> department, List<FacultyModel> faculty)
        {
            Department = department;
            Faculty = faculty;
        }
    }
}
