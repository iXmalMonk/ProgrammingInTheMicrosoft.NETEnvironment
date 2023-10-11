using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ClassLibraryDistributionOfStudyLoad.Serialization
{
    [Serializable]
    public class SerializeLoad
    {
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Load> Loads { get; set; } = new List<Load>();

        public static void Save(string fileName, SerializeType type)
        {
            var serializeLoad = new SerializeLoad();
            var loadData = LoadData.Instance;

            foreach(var teacher in loadData.Teachers)
            {
                serializeLoad.Teachers.Add(teacher);
            }

            foreach(var subject in loadData.Subjects)
            {
                serializeLoad.Subjects.Add(subject);
            }

            foreach(var load in loadData.Loads)
            {
                serializeLoad.Loads.Add(load);
            }

            switch (type)
            {
                case SerializeType.BINARY:
                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    using (FileStream binaryFileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        #pragma warning disable SYSLIB0011
                        binaryFormatter.Serialize(binaryFileStream, serializeLoad);
                    }
                    break;
                case SerializeType.JSON:
                    JsonSerializer jsonSerializer = new JsonSerializer
                    {
                        Formatting = Formatting.Indented
                    };

                    using (StreamWriter jsonStreamWriter = File.CreateText(fileName))
                    {
                        jsonSerializer.Serialize(jsonStreamWriter, serializeLoad);
                    }
                    break;
                case SerializeType.XML:
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializeLoad));

                    using (StreamWriter xmlStreamWriter = new StreamWriter(fileName))
                    {
                        xmlSerializer.Serialize(xmlStreamWriter, serializeLoad);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static void Load(string fileName, SerializeType type)
        {
            SerializeLoad serializeLoad;

            switch (type)
            {
                case SerializeType.BINARY:
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    FileStream binaryFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                    serializeLoad = (SerializeLoad)binaryFormatter.Deserialize(binaryFileStream);
                    binaryFileStream.Close();
                    break;
                case SerializeType.JSON:
                    StreamReader jsonStreamReader = File.OpenText(fileName);
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    serializeLoad = (SerializeLoad)jsonSerializer.Deserialize(jsonStreamReader, typeof(SerializeLoad));
                    jsonStreamReader.Close();
                    break;
                case SerializeType.XML:
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializeLoad));
                    StreamReader xmlStreamReader = new StreamReader(fileName);
                    serializeLoad = (SerializeLoad)xmlSerializer.Deserialize(xmlStreamReader);
                    xmlStreamReader.Close();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            var loadData = LoadData.Instance;
            var teachers = loadData.Teachers.ToList();
            var subjects = loadData.Subjects.ToList();
            var loads = loadData.Loads.ToList();

            foreach (var teacher in teachers)
            {
                loadData.RemoveTeacher(teacher.Name);
            }

            foreach (var subject in subjects)
            {
                loadData.RemoveSubject(subject.Name);
            }

            foreach (var load in loads)
            {
                loadData.RemoveLoad(load);
            }

            var dictionaryTeacher = new Dictionary<string, Teacher>();
            var dictionarySubject = new Dictionary<string, Subject>();

            foreach (var t in serializeLoad.Teachers)
            {
                dictionaryTeacher.Add(t.Name, t);
                loadData.AddTeacher(t);
            }

            foreach (var s in serializeLoad.Subjects)
            {
                dictionarySubject.Add(s.Name, s);
                loadData.AddSubject(s);
            }

            foreach (var l in serializeLoad.Loads)
            {
                loadData.AddLoad(new Load
                {
                    Teacher = dictionaryTeacher[l.Teacher.Name],
                    Subject = dictionarySubject[l.Subject.Name],
                    GroupNumber = l.GroupNumber,
                });
            }
        }
    }
}
