namespace Program
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subject = new ClassLibraryDistributionOfStudyLoad.Subject();
            FormSubject formSubject = new FormSubject(Subject);
            if (formSubject.ShowDialog() == DialogResult.OK)
            {
                Subject = formSubject.Subject;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSubject formSubject = new FormSubject(Subject);
            if (formSubject.ShowDialog() == DialogResult.OK)
            {
                Subject = formSubject.Subject;
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Teacher = new ClassLibraryDistributionOfStudyLoad.Teacher();
            FormTeacher formTeacher = new FormTeacher(Teacher);
            if (formTeacher.ShowDialog() == DialogResult.OK)
            {
                Teacher = formTeacher.Teacher;
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormTeacher formTeacher = new FormTeacher(Teacher);
            if (formTeacher.ShowDialog() == DialogResult.OK)
            {
                Teacher = formTeacher.Teacher;
            }
        }
    }
}
