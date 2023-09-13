namespace Lab_work_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Size = new Size(300, 500);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Opacity = 1;
        }
    }
}