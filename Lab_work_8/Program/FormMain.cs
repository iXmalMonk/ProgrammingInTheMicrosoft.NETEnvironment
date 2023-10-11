using ClassLibraryDistributionOfStudyLoad;
using ClassLibraryDistributionOfStudyLoad.Serialization;
using Lab_work_5;
using WindowsFormsControlLibraryLoad;

namespace Program
{
    public partial class FormMain : Form
    {
        private readonly LoadData _loadData = LoadData.Instance;
        readonly FormLoad _formLoad = new FormLoad();
        readonly FormSubject _formSubject = new FormSubject();
        readonly FormTeacher _formTeacher = new FormTeacher();

        public FormMain()
        {
            InitializeComponent();
            _loadData.TeachersAdded += _loadData_TeachersAdded;
            _loadData.SubjectsAdded += _loadData_SubjectsAdded;
            _loadData.LoadsAdded += _loadData_LoadsAdded;
            _loadData.TeachersRemoved += _loadData_TeachersRemoved;
            _loadData.SubjectsRemoved += _loadData_SubjectsRemoved;
            _loadData.LoadsRemoved += _loadData_LoadsRemoved;
        }

        private void _loadData_LoadsRemoved(object? sender, EventArgs e)
        {
            var load = sender as Load;
            for (int i = 0; i < tabPage3.Controls.Count; i++)
            {
                if ((tabPage3.Controls[i] as UserControlLoad)?.Load == load)
                {
                    tabPage3.Controls.RemoveAt(i);
                    break;
                }
            }
        }

        private void _loadData_SubjectsRemoved(object? sender, EventArgs e)
        {
            var subject = (string)sender;
            for (int i = 0; i < listViewSubject.Items.Count; i++)
            {
                if (((Subject)listViewSubject.Items[i].Tag).Name == subject)
                {
                    listViewSubject.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _loadData_TeachersRemoved(object? sender, EventArgs e)
        {
            var teacher = (string)sender;
            for (int i = 0; i < listViewTeacher.Items.Count; i++)
            {
                if (((Teacher)listViewTeacher.Items[i].Tag).Name == teacher)
                {
                    listViewTeacher.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _loadData_LoadsAdded(object? sender, EventArgs e)
        {
            var load = sender as Load;
            if (load != null)
            {
                UserControlLoad userControlLoad = new UserControlLoad(load)
                {
                    Dock = DockStyle.Top
                };
                tabPage3.Controls.Add(userControlLoad);
            }
        }

        private void _loadData_SubjectsAdded(object? sender, EventArgs e)
        {
            var subject = sender as Subject;
            if (subject != null)
            {
                listViewSubject.Items.Add(new ListViewItem
                {
                    Tag = subject,
                    Text = subject.ToString()
                });
            }
        }

        private void _loadData_TeachersAdded(object? sender, EventArgs e)
        {
            var teacher = sender as Teacher;
            if (teacher != null)
            {
                listViewTeacher.Items.Add(new ListViewItem
                {
                    Tag = teacher,
                    Text = teacher.ToString()
                });
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject();
            _formSubject.Subject = subject;
            if (_formSubject.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _loadData.AddSubject(subject);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var subject = listViewSubject.SelectedItems[0].Tag as Subject;
                var subjectTemporary = new Subject(subject.Name, subject.NumberOfHours);
                _formSubject.Subject = subject;
                if (_formSubject.ShowDialog() == DialogResult.OK)
                {
                    listViewSubject.SelectedItems[0].Text = _formSubject.Subject.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с предметом");
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            _formTeacher.Teacher = teacher;
            if (_formTeacher.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _loadData.AddTeacher(teacher);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var teacher = listViewTeacher.SelectedItems[0].Tag as Teacher;
                var teacherTemporary = new Teacher(teacher.Surname, teacher.Name, teacher.Patronymic, teacher.AcademicDegree, teacher.JobTitle, teacher.Experience);
                _formTeacher.Teacher = teacher;
                if (_formTeacher.ShowDialog() == DialogResult.OK)
                {
                    listViewTeacher.SelectedItems[0].Text = _formTeacher.Teacher.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с преподавателем");
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Load load = new Load();
            _formLoad.Load = load;
            if (_formLoad.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _loadData.AddLoad(load);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tabPage3.Controls.Count; i++)
                {
                    var userControlLoad = tabPage3.Controls[i] as UserControlLoad;
                    if (userControlLoad != null)
                    {
                        if (userControlLoad.Selected)
                        {
                            var load = userControlLoad.Load;
                            _formLoad.Load = load;
                            if (_formLoad.ShowDialog() == DialogResult.OK)
                            {
                                userControlLoad.Refresh();
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с нагрузкой");
            }
        }

        private void listViewSubject_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var subject = listViewSubject.SelectedItems[0].Tag as Subject;
                    if (subject != null)
                    {
                        _loadData.RemoveSubject(subject.Name);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с предметом");
                }
            }
        }

        private void listViewTeacher_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var teacher = listViewTeacher.SelectedItems[0].Tag as Teacher;
                    if (teacher != null)
                    {
                        _loadData.RemoveTeacher(teacher.Name);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с преподавателем");
                }
            }
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "BinaryFiles|*.bin|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializeLoad.Load(openFileDialog.FileName, SerializeType.BINARY);
            }
        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JsonFiles|*.json|Json files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializeLoad.Load(openFileDialog.FileName, SerializeType.JSON);
            }
        }

        private void xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "XmlFiles|*.xml|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializeLoad.Load(openFileDialog.FileName, SerializeType.XML);
            }
        }

        private void binaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "BinaryFiles|*.bin|All files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializeLoad.Save(saveFileDialog.FileName, SerializeType.BINARY);
            }
        }

        private void jsonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JsonFiles|*.json|Json files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializeLoad.Save(saveFileDialog.FileName, SerializeType.JSON);
            }
        }

        private void xmlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "XmlFiles|*.xml|All files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializeLoad.Save(saveFileDialog.FileName, SerializeType.XML);
            }
        }
    }
}
