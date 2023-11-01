namespace Program
{
    public partial class FormFaculty : Form
    {
        private Faculty _faculty;
        public Faculty Faculty
        {
            get
            {
                return _faculty;
            }
            set
            {
                _faculty = value;
                textBox1.Text = _faculty.Dean;
                textBox2.Text = _faculty.Name;
                numericUpDown1.Value = _faculty.NumberOfStudents;
            }
        }

        public FormFaculty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Faculty.Dean = textBox1.Text;
            Faculty.Name = textBox2.Text;
            Faculty.NumberOfStudents = (int)numericUpDown1.Value;
        }
    }
}
