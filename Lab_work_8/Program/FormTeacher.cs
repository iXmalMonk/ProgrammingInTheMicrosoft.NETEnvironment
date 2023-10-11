using ClassLibraryDistributionOfStudyLoad;

namespace Program
{
    public partial class FormTeacher : Form
    {
        private Teacher _teacher;
        public Teacher Teacher
        {
            get
            {
                return _teacher;
            }
            set
            {
                _teacher = value;
                textBoxSurname.Text = _teacher.Surname;
                textBoxName.Text = _teacher.Name;
                textBoxPatronymic.Text = _teacher.Patronymic;
                comboBoxAcademicDegree.Text = _teacher.AcademicDegree;
                textBoxJobTitle.Text = _teacher.JobTitle;
                numericUpDownExperience.Text = _teacher.Experience.ToString();
            }
        }

        public FormTeacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher.Surname = textBoxSurname.Text;
            Teacher.Name = textBoxName.Text;
            Teacher.Patronymic = textBoxPatronymic.Text;
            Teacher.AcademicDegree = comboBoxAcademicDegree.Text;
            Teacher.JobTitle = textBoxJobTitle.Text;
            int.TryParse(numericUpDownExperience.Text, out int value);
            if (value >= 0)
            {
                Teacher.Experience = value;
            }
            Close();
        }
    }
}
