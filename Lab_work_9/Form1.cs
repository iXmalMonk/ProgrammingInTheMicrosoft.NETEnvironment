using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace Lab_work_9
{
    public partial class Form1 : Form
    {
        private string _path = string.Empty;
        private string _currentEncoding = "UTF8";
        private string _newEncoding = "UTF8";

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private string changeEncoding(string text)
        {
            Encoding currentEncoding = choiceEncoding(_currentEncoding);
            Encoding newEncoding = choiceEncoding(_newEncoding);
            _currentEncoding = _newEncoding;
            byte[] currentBytes = currentEncoding.GetBytes(text);
            byte[] newBytes = Encoding.Convert(currentEncoding, newEncoding, currentBytes);
            char[] chars = new char[newEncoding.GetCharCount(newBytes, 0, newBytes.Length)];
            newEncoding.GetChars(newBytes, 0, newBytes.Length, chars, 0);
            string str = new string(chars);
            return str;
        }

        private Encoding choiceEncoding(string encoding)
        {
            switch (encoding)
            {
                case "ASCII": return Encoding.ASCII;
                case "Latin1": return Encoding.Latin1;
                case "Unicode": return Encoding.Unicode;
                case "UTF32": return Encoding.UTF32;
                default: return Encoding.UTF8;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _path = textBox1.Text;
                textBox2.Text = "";
                using (StreamReader reader = new StreamReader(_path))
                {
                    string text = reader.ReadToEnd();
                    int encoding = comboBox1.SelectedIndex;
                    _newEncoding = (string)comboBox1.Items[encoding];
                    text = changeEncoding(text);
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
            int encoding = comboBox1.SelectedIndex;
            _newEncoding = (string)comboBox1.Items[encoding];
            text = changeEncoding(text);
            textBox2.Text = text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, false))
                {
                    string text = textBox2.Text;
                    string textFile = "";
                    foreach (string t in text.Split('\r'))
                    {
                        textFile += t;
                    }
                    int encoding = comboBox1.SelectedIndex;
                    _newEncoding = (string)comboBox1.Items[encoding];
                    textFile = changeEncoding(textFile);
                    writer.WriteLine(textFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}