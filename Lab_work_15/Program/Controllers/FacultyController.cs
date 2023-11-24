using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Program.Models;

namespace Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        [HttpGet]
        [Route("select")]
        public IActionResult Select()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            List<FacultyModel> faculties = new List<FacultyModel>();
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var command = new NpgsqlCommand("select * from net.faculty", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var faculty = new FacultyModel
                    {
                        Id = reader.GetInt32(0),
                        Dean = reader.GetString(1),
                        Name = reader.GetString(2),
                        NumberOfStudents = reader.GetInt32(3)
                    };
                    faculties.Add(faculty);
                }
                connection.Close();
            }
            return Ok(faculties);
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert(string dean, string name, int numberOfStudents)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var command = new NpgsqlCommand("insert into net.faculty (dean, name, number_of_students) values (@dean, @name, @number_of_students)", connection);
                command.Parameters.AddWithValue("dean", dean);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("number_of_students", numberOfStudents);
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Ok(true);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(int id, string dean, string name, int numberOfStudents)
        {
            try
            {
                var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
                using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var command = new NpgsqlCommand("update net.faculty set dean = @dean, name = @name, number_of_students = @number_of_students where id = @id", connection);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("dean", dean);
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("number_of_students", numberOfStudents);
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
                    var command = new NpgsqlCommand("delete from net.faculty where id = @id", connection);
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
