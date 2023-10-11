namespace ClassLibraryDistributionOfStudyLoad
{
    /// <summary>
    /// Нагрузочные данные
    /// </summary>
    public class LoadData
    {
        /// <summary>
        /// Сущность класса LoadData
        /// </summary>
        private static LoadData _instance;

        public static LoadData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoadData();
                }
                return _instance;
            }
        }
        /// <summary>
        /// Словарь преподавателей
        /// </summary>
        private Dictionary<string, Teacher> _teachers { get; set; } = new Dictionary<string, Teacher>();
        /// <summary>
        /// Словарь предметов
        /// </summary>
        private Dictionary<string, Subject> _subjects { get; set; } = new Dictionary<string, Subject>();
        /// <summary>
        /// Список нагрузок
        /// </summary>
        private List<Load> _loads { get; set; } = new List<Load>();
        /// <summary>
        /// Конструктор
        /// </summary>
        private LoadData()
        {
            
        }
        /// <summary>
        /// Коллекция преподавателей
        /// </summary>
        public IEnumerable<Teacher> Teachers
        {
            get { return _teachers.Values.AsEnumerable(); }
        }
        /// <summary>
        /// Коллекция предметов
        /// </summary>
        public IEnumerable<Subject> Subjects
        {
            get { return _subjects.Values.AsEnumerable(); }
        }
        /// <summary>
        /// Коллекция нагрузок
        /// </summary>
        public IEnumerable<Load> Loads
        {
            get { return _loads; }
        }

        public event EventHandler TeachersAdded;
        public event EventHandler SubjectsAdded;
        public event EventHandler LoadsAdded;
        public event EventHandler TeachersRemoved;
        public event EventHandler SubjectsRemoved;
        public event EventHandler LoadsRemoved;

        /// <summary>
        /// Добавление преподавателя
        /// </summary>
        /// <param name="teacher"></param>
        public void AddTeacher(Teacher teacher)
        {
            if (!teacher.IsValid)
            {
                throw new InvalidOperationException("Информация о преподавателе заполнена некорректно!");
            }
            try
            {
                _teachers.Add(teacher.Name, teacher);
                TeachersAdded?.Invoke(teacher, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("При добавлении преподавателя произошла ошибка", ex);
            }
        }
        /// <summary>
        /// Добавление предмета
        /// </summary>
        /// <param name="subject"></param>
        public void AddSubject(Subject subject)
        {
            if (!subject.IsValid)
            {
                throw new InvalidOperationException("Информация о предмете заполнена некорректно!");
            }
            try
            {
                _subjects.Add(subject.Name, subject);
                SubjectsAdded?.Invoke(subject, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("При добавлении предмета произошла ошибка", ex);
            }
        }
        /// <summary>
        /// Добавление нагрузки
        /// </summary>
        /// <param name="load"></param>
        public void AddLoad(Load load)
        {
            if (!load.IsValid)
            {
                throw new InvalidOperationException("Информация о нагрузке заполнена некорректно!");
            }
            try
            {
                _loads.Add(load);
                LoadsAdded?.Invoke(load, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("При добавлении нагрузки произошла ошибка", ex);
            }
        }
        /// <summary>
        /// Удаление преподавателя
        /// </summary>
        /// <param name="name"></param>
        public void RemoveTeacher(string name)
        {
            _teachers.Remove(name);
            TeachersRemoved?.Invoke(name, EventArgs.Empty);
            var loadsForTeacher = _loads.Where(load => load.Teacher.Name == name).ToList();
            for (int i = 0; i < loadsForTeacher.Count; i++)
            {
                RemoveLoad(loadsForTeacher[i]);
            }
        }
        /// <summary>
        /// Удаление предмета
        /// </summary>
        /// <param name="name"></param>
        public void RemoveSubject(string name)
        {
            _subjects.Remove(name);
            SubjectsRemoved?.Invoke(name, EventArgs.Empty);
            var loadsForSubject = _loads.Where(load => load.Subject.Name == name).ToList();
            for(int i = 0; i < loadsForSubject.Count; i++)
            {
                RemoveLoad(loadsForSubject[i]);
            }
        }
        /// <summary>
        /// Удаление нагрузки
        /// </summary>
        /// <param name="load"></param>
        public void RemoveLoad(Load load)
        {
            _loads.Remove(load);
            LoadsRemoved?.Invoke(load, EventArgs.Empty);
        }
    }
}
