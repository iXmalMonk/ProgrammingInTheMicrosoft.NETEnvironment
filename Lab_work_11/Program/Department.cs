namespace Program
{
    public class Department
    {
        public int Id { get; set; }
        public string Manager { get; set; }
        public string Name { get; set; }
        public int NumberOfTeachers { get; set; }
        public int FacultyId { get; set; }

        public static List<Department> Select(Npgsql.NpgsqlConnection connection)
        {
            List<Department> departments = new List<Department>();
            connection.Open();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("select id, manager, name, number_of_teachers, faculty_id from net.department", connection);
            Npgsql.NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Department department = new Department
                {
                    Id = (int)dataReader["id"],
                    Manager = (string)dataReader["manager"],
                    Name = (string)dataReader["name"],
                    NumberOfTeachers = (int)dataReader["number_of_teachers"],
                    FacultyId = (int)dataReader["faculty_id"],
                };
                departments.Add(department);
            }
            command.Dispose();
            connection.Close();
            return departments;
        }

        public static void Insert(Npgsql.NpgsqlConnection connection, Department department)
        {
            try
            {
                connection.Open();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("insert into net.department(manager, name, number_of_teachers, faculty_id) values(@manager, @name, @number_of_teachers, @faculty_id)", connection);
                command.Parameters.AddWithValue("@manager", department.Manager);
                command.Parameters.AddWithValue("@name", department.Name);
                command.Parameters.AddWithValue("@number_of_teachers", department.NumberOfTeachers);
                command.Parameters.AddWithValue("@faculty_id", department.FacultyId);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Факультета с таким идентификатором не существует");
                connection.Close();
            }
        }

        public static void Update(Npgsql.NpgsqlConnection connection, Department department)
        {
            connection.Open();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("update net.department set manager = @manager, name = @name, number_of_teachers = @number_of_teachers, faculty_id = @faculty_id where id = @id", connection);
            command.Parameters.AddWithValue("@id", department.Id);
            command.Parameters.AddWithValue("@manager", department.Manager);
            command.Parameters.AddWithValue("@name", department.Name);
            command.Parameters.AddWithValue("@number_of_teachers", department.NumberOfTeachers);
            command.Parameters.AddWithValue("@faculty_id", department.FacultyId);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public static void Delete(Npgsql.NpgsqlConnection connection, int id)
        {
            connection.Open();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("delete from net.department where id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }
    }
}
