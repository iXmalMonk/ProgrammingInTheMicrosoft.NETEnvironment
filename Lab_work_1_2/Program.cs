namespace Lab_work_1_2
{
    public class MyForm : Form
    {
        private Button button1;
        private TextBox textBox1;

        public MyForm() => InitializeComponent();

        [STAThread]
        static void Main()
        {
            Application.Run(new MyForm());
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(188, 265);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // MyForm
            // 
            ClientSize = new Size(300, 300);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "MyForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Hello, world!";
        }
    }
}
