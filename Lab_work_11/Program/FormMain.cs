namespace Program
{
    public partial class FormMain : Form
    {
        private readonly Npgsql.NpgsqlConnection _connection;

        public FormMain()
        {
            InitializeComponent();
            _connection = new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=net;User Id = postgres;Password=5683");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var departments = Department.Select(_connection);
            listView1.Items.Clear();
            for (int i = 0; i < departments.Count; i++)
            {
                var department = departments[i];
                var listViewItem = listView1.Items.Add(department.Id.ToString());
                listViewItem.Tag = department;
                listViewItem.SubItems.Add(department.Manager);
                listViewItem.SubItems.Add(department.Name);
                listViewItem.SubItems.Add(department.NumberOfTeachers.ToString());
                listViewItem.SubItems.Add(department.FacultyId.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormDepartment formDepartment = new FormDepartment
            {
                Department = new Department()
            };
            if (formDepartment.ShowDialog() == DialogResult.OK)
            {
                Department.Insert(_connection, formDepartment.Department);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormDepartment formDepartment = new FormDepartment
            {
                Department = (Department)listView1.SelectedItems[0].Tag
            };
            if (formDepartment.ShowDialog() == DialogResult.OK)
            {
                Department.Update(_connection, formDepartment.Department);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Department.Delete(_connection, ((Department)listView1.SelectedItems[0].Tag).Id);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var faculties = Faculty.Select(_connection);
            listView2.Items.Clear();
            for (int i = 0; i < faculties.Count; i++)
            {
                var faculty = faculties[i];
                var listViewItem = listView2.Items.Add(faculty.Id.ToString());
                listViewItem.Tag = faculty;
                listViewItem.SubItems.Add(faculty.Dean);
                listViewItem.SubItems.Add(faculty.Name);
                listViewItem.SubItems.Add(faculty.NumberOfStudents.ToString());
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FormFaculty formFaculty = new FormFaculty
            {
                Faculty = new Faculty()
            };
            if (formFaculty.ShowDialog() == DialogResult.OK)
            {
                Faculty.Insert(_connection, formFaculty.Faculty);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            FormFaculty formFaculty = new FormFaculty
            {
                Faculty = (Faculty)listView2.SelectedItems[0].Tag
            };
            if (formFaculty.ShowDialog() == DialogResult.OK)
            {
                Faculty.Update(_connection, formFaculty.Faculty);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Faculty.Delete(_connection, ((Faculty)listView2.SelectedItems[0].Tag).Id);
        }
    }
}
