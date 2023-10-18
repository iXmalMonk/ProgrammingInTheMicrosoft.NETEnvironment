using System.Text.RegularExpressions;

namespace Lab_work_9_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBox1.Text;
                textBox2.Text = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    string text = reader.ReadToEnd();
                    foreach (string t in text.Split('\n'))
                    {
                        textBox2.Text += t + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            string pattern = @"(?<=set\s*{)[^{}]+(?=})";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(text);
            List<string> list = new List<string>();
            while (match.Success)
            {
                list.Add(match.Groups[0].Value);
                match = match.NextMatch();
            }
            textBox3.Text = "";
            foreach (string l in list)
            {
                textBox3.Text += l + "\r\n";
            }
        }
    }
}