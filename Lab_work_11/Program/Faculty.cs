namespace Program
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Dean { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }

        public static List<Faculty> Select(Npgsql.NpgsqlConnection connection)
        {
            List<Faculty> faculties = new List<Faculty>();
            connection.Open();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("select id, dean, name, number_of_students from net.faculty", connection);
            Npgsql.NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Faculty faculty = new Faculty
                {
                    Id = (int)dataReader["id"],
                    Dean = (string)dataReader["dean"],
                    Name = (string)dataReader["name"],
                    NumberOfStudents = (int)dataReader["number_of_students"],
                };
                faculties.Add(faculty);
            }
            command.Dispose();
            connection.Close();
            return faculties;
        }

        public static void Insert(Npgsql.NpgsqlConnection connection, Faculty faculty)
        {
            connection.Open();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("insert into net.faculty(dean, name, number_of_students) values(@dean, @name, @number_of_students)", connection);
            command.Parameters.AddWithValue("@dean", faculty.Dean);
            command.Parameters.AddWithValue("@name", faculty.Name);
            command.Parameters.AddWithValue("@number_of_students", faculty.NumberOfStudents);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public static void Update(Npgsql.NpgsqlConnection connection, Faculty faculty)
        {
            connection.Open();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("update net.faculty set dean = @dean, name = @name, number_of_students = @number_of_students where id = @id", connection);
            command.Parameters.AddWithValue("@id", faculty.Id);
            command.Parameters.AddWithValue("@dean", faculty.Dean);
            command.Parameters.AddWithValue("@name", faculty.Name);
            command.Parameters.AddWithValue("@number_of_students", faculty.NumberOfStudents);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public static void Delete(Npgsql.NpgsqlConnection connection, int id)
        {
            connection.Open();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("delete from net.faculty where id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }
    }
}
