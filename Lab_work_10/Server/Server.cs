using ClassLibraryCinemas;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class Server
    {
        private static ConcurrentDictionary<string, Cinemas> _cinemas = new ConcurrentDictionary<string, Cinemas>();

        public static void Main()
        {
            try
            {
                StreamReader streamReader = File.OpenText("store.json");
                JsonSerializer jsonSerializer = new JsonSerializer();
                _cinemas = (ConcurrentDictionary<string, Cinemas>)jsonSerializer.Deserialize(streamReader, typeof(ConcurrentDictionary<string, Cinemas>));
                streamReader.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            IPHostEntry ipHostEntry = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHostEntry.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 11000);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            socket.Listen(10);
            try
            {
                while (true)
                {
                    Console.WriteLine("Ожидание соединения через порт {0}", ipEndPoint);
                    Socket secondSocket = socket.Accept();
                    Task task = new Task(Action, secondSocket);
                    task.Start();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Action(object o)
        {
            Socket socket = o as Socket;
            if (socket != null)
            {
                Thread thread = new Thread(autoSave);
                thread.Start();
                while (true)
                {
                    try
                    {
                        byte[] bytes = new byte[10240];
                        int receive = socket.Receive(bytes);
                        string getString = Encoding.UTF8.GetString(bytes, 0, receive);
                        CinemasResponse cinemasResponse = new CinemasResponse() { IsSuccess = false };
                        try
                        {
                            var deserializeObject = JsonConvert.DeserializeObject<CinemasRequest>(getString);
                            if (deserializeObject != null)
                            {
                                cinemasResponse.Key = deserializeObject.Key;
                                Cinemas cinemas;
                                switch (deserializeObject.CinemasRequestType)
                                {
                                    case CinemasRequestType.ADD:
                                        if (_cinemas.ContainsKey(deserializeObject.Key))
                                        {
                                            cinemasResponse.ErrorMessage = "Кинотеатр с таким ключем уже существует";
                                        }
                                        else
                                        {
                                            _cinemas.AddOrUpdate(deserializeObject.Key, deserializeObject.Cinemas, (cinemasSecond, cinemasThird) => deserializeObject.Cinemas);
                                            cinemasResponse.IsSuccess = true;
                                        }
                                        break;
                                    case CinemasRequestType.GET:
                                        if (_cinemas.TryGetValue(deserializeObject.Key, out cinemas))
                                        {
                                            cinemasResponse.Cinemas = cinemas;
                                            cinemasResponse.IsSuccess = true;
                                        }
                                        else
                                        {
                                            cinemasResponse.ErrorMessage = "Кинотеатр с таким ключем не найден";
                                        }
                                        break;
                                    case CinemasRequestType.REMOVE:
                                        if (_cinemas.ContainsKey(deserializeObject.Key))
                                        {
                                            if (_cinemas.TryRemove(deserializeObject.Key, out cinemas))
                                            {
                                                cinemasResponse.IsSuccess = true;
                                            }
                                            else
                                            {
                                                cinemasResponse.ErrorMessage = "Кинотеатр не удалось удалить";
                                            }
                                        }
                                        else
                                        {
                                            cinemasResponse.ErrorMessage = "Кинотеатр с таким ключем не найден";
                                        }
                                        break;
                                    case CinemasRequestType.UPDATE:
                                        if (_cinemas.ContainsKey(deserializeObject.Key))
                                        {
                                            _cinemas.AddOrUpdate(deserializeObject.Key, deserializeObject.Cinemas, (cinemasSecond, cinemasThird) => deserializeObject.Cinemas);
                                            cinemasResponse.IsSuccess = true;
                                        }
                                        else
                                        {
                                            cinemasResponse.ErrorMessage = "Кинотеатр с таким ключем не найден";
                                        }
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            cinemasResponse.ErrorMessage = exception.Message;
                        }
                        Console.WriteLine("Полученный json: " + getString);
                        var serializeObject = JsonConvert.SerializeObject(cinemasResponse);
                        byte[] getBytes = Encoding.UTF8.GetBytes(serializeObject);
                        Console.WriteLine("Отправленный json: " + getString);
                        socket.Send(getBytes);
                    }
                    catch
                    {
                        break;
                    }
                    thread.Interrupt();
                    using (StreamWriter streamWriter = File.CreateText("store.json"))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer { Formatting = Formatting.Indented };
                        jsonSerializer.Serialize(streamWriter, _cinemas);
                    }
                }
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }

        private static void autoSave()
        {
            try
            {
                while (true)
                {
                    using (StreamWriter streamWriter = File.CreateText("store.json"))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer { Formatting = Formatting.Indented };
                        jsonSerializer.Serialize(streamWriter, _cinemas);
                    }

                    Thread.Sleep(10000);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}