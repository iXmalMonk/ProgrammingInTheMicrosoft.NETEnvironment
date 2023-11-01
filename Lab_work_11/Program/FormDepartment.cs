namespace Program
{
    public partial class FormDepartment : Form
    {
        private Department _department;
        public Department Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                textBox1.Text = _department.Manager;
                textBox2.Text = _department.Name;
                numericUpDown1.Value = _department.NumberOfTeachers;
                numericUpDown2.Value = _department.FacultyId;
            }
        }

        public FormDepartment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Department.Manager = textBox1.Text;
            Department.Name = textBox2.Text;
            Department.NumberOfTeachers = (int)numericUpDown1.Value;
            Department.FacultyId = (int)numericUpDown2.Value;
        }
    }
}
