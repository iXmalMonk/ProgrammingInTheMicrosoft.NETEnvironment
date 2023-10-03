using ClassLibraryDistributionOfStudyLoad;

namespace Program
{
    public partial class FormSubject : Form
    {
        private Subject _subject;
        public Subject Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
                textBoxName.Text = _subject.Name;
                numericUpDownNumberOfHours.Text = _subject.NumberOfHours.ToString();
            }
        }

        public FormSubject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subject.Name = textBoxName.Text;
            int.TryParse(numericUpDownNumberOfHours.Text, out int value);
            if (value > 0)
            {
                Subject.NumberOfHours = value;
            }
            Close();
        }
    }
}
