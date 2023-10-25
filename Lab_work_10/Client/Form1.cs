using ClassLibraryCinemas;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class Form1 : Form
    {
        private byte[] _bytes;
        private int _counter = 0;
        private Socket _socket;

        public Form1()
        {
            InitializeComponent();
            _bytes = new byte[10240];
            IPHostEntry ipHostEntry = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHostEntry.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 11000);
            _socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(ipEndPoint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CinemasRequest cinemasRequest = null;
                cinemasRequest = new CinemasRequest
                {
                    Cinemas = new Cinemas
                    {
                        Name = textBox1.Text,
                        Rating = (int)numericUpDown1.Value
                    },
                    Key = textBox1.Text,
                    CinemasRequestType = CinemasRequestType.ADD
                };
                Socket socket = _socket;
                if (socket != null)
                {
                    string serializeObject = JsonConvert.SerializeObject(cinemasRequest);
                    byte[] getBytes = Encoding.UTF8.GetBytes(serializeObject);
                    socket.Send(getBytes);
                    int receive = socket.Receive(_bytes); //
                    _counter++;
                    string text = textBox2.Text;
                    textBox2.Text = (text + "¹" + _counter + ":" + serializeObject + "\r\n" + Encoding.UTF8.GetString(_bytes, 0, receive) + "\r\n\r\n");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CinemasRequest cinemasRequest = null;
                string key = textBox1.Text;
                cinemasRequest = new CinemasRequest
                {
                    Key = key,
                    CinemasRequestType = CinemasRequestType.GET
                };
                Socket socket = _socket;
                if (socket != null)
                {
                    string serializeObject = JsonConvert.SerializeObject(cinemasRequest);
                    byte[] getBytes = Encoding.UTF8.GetBytes(serializeObject);
                    socket.Send(getBytes);
                    int receive = socket.Receive(_bytes);
                    _counter++;
                    string getString = Encoding.UTF8.GetString(_bytes, 0, receive);
                    var deserializeObject = JsonConvert.DeserializeObject<CinemasRequest>(getString);
                    textBox1.Text = deserializeObject.Cinemas.Name;
                    numericUpDown1.Value = deserializeObject.Cinemas.Rating;
                    string text = textBox2.Text;
                    textBox2.Text = (text + "¹" + _counter + ":" + serializeObject + "\r\n" + Encoding.UTF8.GetString(_bytes, 0, receive) + "\r\n\r\n");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CinemasRequest cinemasRequest = null;
                string key = textBox1.Text;
                cinemasRequest = new CinemasRequest
                {
                    Key = key,
                    CinemasRequestType = CinemasRequestType.REMOVE
                };
                Socket socket = _socket;
                if (socket != null)
                {
                    string jsonRequest = JsonConvert.SerializeObject(cinemasRequest);
                    byte[] buffer = Encoding.UTF8.GetBytes(jsonRequest);
                    socket.Send(buffer);
                    int bytesReceive = socket.Receive(_bytes);
                    _counter++;
                    string text = textBox2.Text;
                    textBox2.Text = (text + "¹" + _counter + ":" + jsonRequest + "\r\n" + Encoding.UTF8.GetString(_bytes, 0, bytesReceive) + "\r\n\r\n");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                CinemasRequest cinemasRequest = null;
                string key = textBox1.Text;
                cinemasRequest = new CinemasRequest
                {
                    Cinemas = new Cinemas
                    {
                        Name = textBox1.Text,
                        Rating = (int)numericUpDown1.Value
                    },
                    Key = key,
                    CinemasRequestType = CinemasRequestType.UPDATE
                };
                Socket socket = _socket;
                if (socket != null)
                {
                    string serializeObject = JsonConvert.SerializeObject(cinemasRequest);
                    byte[] getBytes = Encoding.UTF8.GetBytes(serializeObject);
                    socket.Send(getBytes);
                    int receive = socket.Receive(_bytes);
                    _counter++;
                    string text = textBox2.Text;
                    textBox2.Text = (text + "¹" + _counter + ":" + serializeObject + "\r\n" + Encoding.UTF8.GetString(_bytes, 0, receive) + "\r\n\r\n");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}