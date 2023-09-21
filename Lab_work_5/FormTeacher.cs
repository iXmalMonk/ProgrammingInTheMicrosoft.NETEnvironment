using ClassLibraryDistributionOfStudyLoad;

namespace Program
{
    public partial class FormTeacher : Form
    {
        public Teacher Teacher { get; set; }

        public FormTeacher(Teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
            textBox1.Text = teacher.Surname;
            textBox2.Text = teacher.Name;
            textBox3.Text = teacher.Patronymic;
            comboBox1.Text = teacher.AcademicDegree;
            textBox4.Text = teacher.JobTitle;
            textBox5.Text = $"{teacher.Experience}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher.Surname = textBox1.Text;
            Teacher.Name = textBox2.Text;
            Teacher.Patronymic = textBox3.Text;
            Teacher.AcademicDegree = comboBox1.Text;
            Teacher.JobTitle = textBox4.Text;
            int.TryParse(textBox5.Text, out int value);
            if (value >= 0)
            {
                Teacher.Experience = value;
            }
            Close();
        }
    }
}
