namespace ClassLibraryDistributionOfStudyLoad
{
    /// <summary>
    /// Нагрузка
    /// </summary>
    public class Load : IValidatable
    {
        /// <summary>
        /// Преподаватель
        /// </summary>
        public Teacher Teacher { get; set; }
        /// <summary>
        /// Предмет
        /// </summary>
        public Subject Subject { get; set; }
        /// <summary>
        /// Номер группы
        /// </summary>
        public int GroupNumber { get; set; }

        public bool IsValid
        {
            get
            {
                if (Teacher == null) { return false; }
                if (Subject == null) { return false; }
                if (GroupNumber <= 0) { return false; }
                return true;
            }
        }

        public Load()
        {
            Teacher = new Teacher();
            Subject = new Subject();
            GroupNumber = 0;
        }

        public Load(Teacher teacher, Subject subject, int groupNumber)
        {
            Teacher = teacher;
            Subject = subject;
            GroupNumber = groupNumber;
        }

        public override string ToString()
        {
            return $"Преподаватель: {Teacher}\r\n Предмет: {Subject}\r\n Номер группы: {GroupNumber}\r\n";
        }
    }
}
