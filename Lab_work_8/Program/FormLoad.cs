using ClassLibraryDistributionOfStudyLoad;

namespace Lab_work_5
{
    public partial class FormLoad : Form
    {
        private readonly LoadData _loadData = LoadData.Instance;
        private Load _load;
        public Load Load
        {
            get
            {
                return _load;
            }
            set
            {
                _load = value;
                comboBoxSubject.SelectedItem = _load.Subject.ToString();
                comboBoxTeacher.SelectedItem = _load.Teacher.ToString();
                textBoxGroupNumber.Text = _load.GroupNumber.ToString();
            }
        }

        public FormLoad()
        {
            InitializeComponent();
            _loadData.TeachersAdded += _loadData_TeachersAdded;
            _loadData.SubjectsAdded += _loadData_SubjectsAdded;
            _loadData.TeachersRemoved += _loadData_TeachersRemoved;
            _loadData.SubjectsRemoved += _loadData_SubjectsRemoved;
            foreach (var teacher in _loadData.Teachers)
            {
                comboBoxTeacher.Items.Add(teacher);
            }
            foreach (var subject in _loadData.Subjects)
            {
                comboBoxSubject.Items.Add(subject);
            }
        }

        private void _loadData_SubjectsRemoved(object? sender, EventArgs e)
        {
            var name = (string)sender;
            for (int i = 0; i < comboBoxSubject.Items.Count; i++)
            {
                var subject = comboBoxSubject.Items[i] as Subject;
                if (subject.Name == name)
                {
                    comboBoxSubject.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _loadData_TeachersRemoved(object? sender, EventArgs e)
        {
            var name = (string)sender;
            for (int i = 0; i < comboBoxTeacher.Items.Count; i++)
            {
                var teacher = comboBoxTeacher.Items[i] as Teacher;
                if (teacher.Name == name)
                {
                    comboBoxTeacher.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _loadData_SubjectsAdded(object? sender, EventArgs e)
        {
            comboBoxSubject.Items.Add(sender);
        }

        private void _loadData_TeachersAdded(object? sender, EventArgs e)
        {
            comboBoxTeacher.Items.Add(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load.Teacher = comboBoxTeacher.SelectedItem as Teacher;
            Load.Subject = comboBoxSubject.SelectedItem as Subject;
            int.TryParse(textBoxGroupNumber.Text, out int value);
            if (value >= 0)
            {
                Load.GroupNumber = value;
            }
            Close();
        }
    }
}
