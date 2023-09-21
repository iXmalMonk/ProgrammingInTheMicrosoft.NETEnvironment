using ClassLibraryDistributionOfStudyLoad;

namespace Program
{
    public partial class FormSubject : Form
    {
        public Subject Subject { get; set; }

        public FormSubject(Subject subject)
        {
            InitializeComponent();
            Subject = subject;
            textBox1.Text = Subject.Name;
            textBox2.Text = $"{Subject.NumberOfHours}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subject.Name = textBox1.Text;
            int.TryParse(textBox2.Text, out int value);
            if (value > 0)
            {
                Subject.NumberOfHours = value;
            }
            Close();
        }
    }
}
