namespace Lab_work_2_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult;
            Form2 form2 = new Form2();
            dialogResult = form2.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                MessageBox.Show("Your name is " + form2.textBox1.Text + " " + form2.textBox2.Text);
            }
            linkLabel1.LinkVisited = true;
        }
    }
}