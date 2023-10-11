namespace ProgramSecond
{
    public partial class Form1 : Form
    {
        private string _path;
        private FileSystemWatcher _watcher;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _path = textBox1.Text;
                textBox2.Text = "";

                using (StreamReader streamReader = new StreamReader(_path))
                {
                    string text = streamReader.ReadToEnd();

                    foreach (string s in text.Split('\n'))
                    {
                        textBox2.Text += s + "\r\n";
                    }

                    string dir = _path.Substring(0, _path.LastIndexOf('\\'));

                    _watcher = new FileSystemWatcher(dir, "*.txt");
                    _watcher.Changed += FileChanged;
                    _watcher.IncludeSubdirectories = true;
                    _watcher.EnableRaisingEvents = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter(_path, false))
            {
                string text = textBox2.Text;
                string textFile = "";

                foreach (string s in text.Split('\r'))
                {
                    textFile += s;
                }

                streamWriter.WriteLine(textFile);
            }
        }

        void FileChanged(object o, FileSystemEventArgs e)
        {
            try
            {
                textBox2.Invoke(() =>
                {
                    textBox2.Text = "";
                });

                using (StreamReader streamReader = new StreamReader(_path))
                {
                    string text = streamReader.ReadToEnd();

                    foreach (string s in text.Split('\n'))
                    {
                        textBox2.Invoke(() =>
                        {
                            textBox2.Text += s + "\r\n";
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}