using ClassLibraryDistributionOfStudyLoad;
using Lab_work_5;

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
            for (int i = 0; i < listViewLoad.Items.Count; i++)
            {
                if ((Load)listViewLoad.Items[i].Tag == load)
                {
                    listViewLoad.Items.RemoveAt(i);
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
                ListViewItem listViewItem = new ListViewItem
                {
                    Tag = load,
                    Text = load.Teacher.ToString()
                };
                listViewItem.SubItems.Add(load.Subject.ToString());
                listViewItem.SubItems.Add(load.GroupNumber.ToString());
                listViewLoad.Items.Add(listViewItem);
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
                    for (int i = 0; i < listViewLoad.Items.Count; i++)
                    {
                        for (int j = 0; j < listViewLoad.Items[i].SubItems.Count; j++)
                        {
                            if (listViewLoad.Items[i].SubItems[j].Text == subjectTemporary.ToString())
                            {
                                listViewLoad.Items[i].SubItems[j].Text = subject.ToString();
                            }
                        }
                    }
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
                    for (int i = 0; i < listViewLoad.Items.Count; i++)
                    {
                        for (int j = 0; j < listViewLoad.Items[i].SubItems.Count; j++)
                        {
                            if (listViewLoad.Items[i].SubItems[j].Text == teacherTemporary.ToString())
                            {
                                listViewLoad.Items[i].SubItems[j].Text = teacher.ToString();
                            }
                        }
                    }
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
                var load = listViewLoad.SelectedItems[0].Tag as Load;
                _formLoad.Load = load;
                if (_formLoad.ShowDialog() == DialogResult.OK)
                {
                    listViewLoad.SelectedItems[0].Text = _formLoad.Load.ToString();
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

        private void listViewLoad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var load = listViewLoad.SelectedItems[0].Tag as Load;
                    if (load != null)
                    {
                        _loadData.RemoveLoad(load);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с нагрузкой");
                }
            }
        }
    }
}
