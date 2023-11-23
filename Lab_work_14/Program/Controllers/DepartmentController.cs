using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Program.Models;

namespace Program.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            List<DepartmentModel> departments = new List<DepartmentModel>();
            List<FacultyModel> faculties = new List<FacultyModel>();
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var firstCommand = new NpgsqlCommand("select * from net.department", connection);
                var firstReader = firstCommand.ExecuteReader();
                while (firstReader.Read())
                {
                    var department = new DepartmentModel
                    {
                        Id = firstReader.GetInt32(0),
                        Image = firstReader.IsDBNull(1) ? null : firstReader.GetFieldValue<byte[]>(1),
                        Manager = firstReader.GetString(2),
                        Name = firstReader.GetString(3),
                        NumberOfTeachers = firstReader.GetInt32(4),
                        FacultyId = firstReader.GetInt32(5)
                    };
                    departments.Add(department);
                }
                firstReader.Close();
                var secondCommand = new NpgsqlCommand("select * from net.faculty", connection);
                var secondReader = secondCommand.ExecuteReader();
                while (secondReader.Read())
                {
                    var faculty = new FacultyModel
                    {
                        Id = secondReader.GetInt32(0),
                        Dean = secondReader.GetString(1),
                        Name = secondReader.GetString(2),
                        NumberOfStudents = secondReader.GetInt32(3)
                    };
                    faculties.Add(faculty);
                }
                secondReader.Close();
                connection.Close();
            }
            Models.Models models = new Models.Models(departments, faculties);
            return View(models);
        }

        [HttpPost]
        public IActionResult Insert(IFormFile image, string manager, string name, int numberOfTeachers, int facultyId)
        {
            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var command = new NpgsqlCommand("insert into net.department (image, manager, name, number_of_teachers, faculty_id) values (@image, @manager, @name, @number_of_teachers, @faculty_id)", connection);
                command.Parameters.AddWithValue("image", imageBytes);
                command.Parameters.AddWithValue("manager", manager);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("number_of_teachers", numberOfTeachers);
                command.Parameters.AddWithValue("faculty_id", facultyId);
                command.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id, IFormFile image, string manager, string name, int numberOfTeachers, int facultyId)
        {
            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var command = new NpgsqlCommand("update net.department set image = @image, manager = @manager, name = @name, number_of_teachers = @number_of_teachers, faculty_id = @faculty_id where id = @id", connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("image", imageBytes);
                command.Parameters.AddWithValue("manager", manager);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("number_of_teachers", numberOfTeachers);
                command.Parameters.AddWithValue("faculty_id", facultyId);
                command.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var command = new NpgsqlCommand("delete from net.department where id = @id", connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Index");
        }
    }
}
