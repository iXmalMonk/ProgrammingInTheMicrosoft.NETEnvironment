using ClassLibraryDistributionOfStudyLoad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibraryLoad
{
    public partial class UserControlLoad : UserControl
    {
        private readonly LoadData _loadData = LoadData.Instance;
        public Load Load { get; }
        private bool _selected;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (value)
                {
                    var controls = Parent?.Controls;
                    if (controls != null)
                    {
                        foreach (var control in controls)
                        {
                            if (!(control is UserControlLoad))
                            {
                                continue;
                            }
                            var userControlLoad = control as UserControlLoad;
                            if (userControlLoad != this)
                            {
                                userControlLoad.Selected = false;
                            }
                        }
                    }
                }
                _selected = value;
                Refresh();
            }
        }

        public UserControlLoad(Load load)
        {
            InitializeComponent();
            Load = load;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                _loadData.RemoveLoad(Load);
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана запись о нагрузке");
            }
        }

        private void UserControlLoad_Click(object sender, EventArgs e)
        {
            Selected = true;
        }

        private void UserControlLoad_Paint(object sender, PaintEventArgs e)
        {
            textBoxTeacher.Text = $@"{Load.Teacher.Name} {Load.Teacher.Surname} {Load.Teacher.Patronymic} {Load.Teacher.AcademicDegree} {Load.Teacher.Experience} {Load.Teacher.JobTitle}";
            textBoxSubject.Text = $@"{Load.Subject.Name} {Load.Subject.NumberOfHours}";
            textBoxGroupNumber.Text = $@"{Load.GroupNumber}";
            BackColor = _selected ? Color.AliceBlue : DefaultBackColor;
        }
    }
}
