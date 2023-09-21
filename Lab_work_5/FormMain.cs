using ClassLibraryDistributionOfStudyLoad;
using Lab_work_5;

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
            Subject subject = new Subject();
            FormSubject formSubject = new FormSubject(subject);
            formSubject.ShowDialog();
            LoadData.Subjects.Add(subject.Name, subject);
            UpdateSubjectList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Subject subject = listView1.SelectedItems[0].Tag as Subject;
                FormSubject formSubject = new FormSubject(subject);
                formSubject.ShowDialog();
                UpdateSubjectList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateSubjectList()
        {
            listView1.Items.Clear();
            foreach (var subject in LoadData.Subjects)
            {
                listView1.Items.Add(new ListViewItem
                {
                    Tag = subject.Value,
                    Text = subject.Value.ToString()
                });
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            FormTeacher formTeacher = new FormTeacher(teacher);
            formTeacher.ShowDialog();
            LoadData.Teachers.Add(teacher.Name, teacher);
            UpdateTeacherList();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Teacher teacher = listView2.SelectedItems[0].Tag as Teacher;
                FormTeacher formTeacher = new FormTeacher(teacher);
                formTeacher.ShowDialog();
                UpdateTeacherList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateTeacherList()
        {
            listView2.Items.Clear();
            foreach (var teacher in LoadData.Teachers)
            {
                listView2.Items.Add(new ListViewItem
                {
                    Tag = teacher.Value,
                    Text = teacher.Value.ToString()
                });
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Load load = new Load();
            FormLoad formLoad = new FormLoad(load);
            formLoad.ShowDialog();
            LoadData.Loads.Add(load);
            UpdateLoadList();
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                Load load = listView3.SelectedItems[0].Tag as Load;
                FormLoad formLoad = new FormLoad(load);
                formLoad.ShowDialog();
                UpdateLoadList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateLoadList()
        {
            listView3.Items.Clear();
            foreach (var load in LoadData.Loads)
            {
                ListViewItem listViewItem = new ListViewItem
                {
                    Tag = load,
                    Text = load.Teacher.ToString()
                };
                listViewItem.SubItems.Add(load.Subject.ToString());
                listViewItem.SubItems.Add(load.GroupNumber.ToString());
                listView3.Items.Add(listViewItem);
            }
        }
    }
}
