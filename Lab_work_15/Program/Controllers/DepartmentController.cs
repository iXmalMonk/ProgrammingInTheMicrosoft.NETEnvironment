using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Program.Models;

namespace Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        [Route("select")]
        public IActionResult Select()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            List<DepartmentModel> departments = new List<DepartmentModel>();
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var command = new NpgsqlCommand("select * from net.department", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var department = new DepartmentModel
                    {
                        Id = reader.GetInt32(0),
                        Image = reader.IsDBNull(1) ? null : reader.GetFieldValue<byte[]>(1),
                        Manager = reader.GetString(2),
                        Name = reader.GetString(3),
                        NumberOfTeachers = reader.GetInt32(4),
                        FacultyId = reader.GetInt32(5)
                    };
                    departments.Add(department);
                }
                connection.Close();
            }
            return Ok(departments);
        }

        [HttpPost]
        [Route("insert")]
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
            return Ok(true);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(int id, IFormFile image, string manager, string name, int numberOfTeachers, int facultyId)
        {
            try
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
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            try
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
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }
    }
}
