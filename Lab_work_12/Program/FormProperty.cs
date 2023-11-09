namespace Program
{
    public partial class FormProperty : Form
    {
        public FormProperty(PictureBox pictureBox)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = pictureBox;
            propertyGrid2.SelectedObject = pictureBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
