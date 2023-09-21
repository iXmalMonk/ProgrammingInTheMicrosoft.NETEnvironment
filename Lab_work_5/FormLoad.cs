using ClassLibraryDistributionOfStudyLoad;

namespace Lab_work_5
{
    public partial class FormLoad : Form
    {
        public Load Load;

        public FormLoad(Load load)
        {
            InitializeComponent();
            Load = load;
            foreach (var teacher in LoadData.Teachers)
            {
                comboBox1.Items.Add(teacher.Value);
            }
            foreach (var subject in LoadData.Subjects)
            {
                comboBox2.Items.Add(subject.Value);
            }
            comboBox1.SelectedItem = Load.Teacher;
            comboBox2.SelectedItem = Load.Subject;
            textBox1.Text = $"{Load.GroupNumber}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load.Teacher = comboBox1.SelectedItem as Teacher;
            Load.Subject = comboBox2.SelectedItem as Subject;
            int.TryParse(textBox1.Text, out int value);
            if (value >= 0)
            {
                Load.GroupNumber = value;
            }
            Close();
        }
    }
}
