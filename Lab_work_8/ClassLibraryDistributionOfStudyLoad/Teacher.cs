namespace ClassLibraryDistributionOfStudyLoad
{
    /// <summary>
    /// Преподаватель
    /// </summary>
    [Serializable]
    public class Teacher : IValidatable
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Ученая степень
        /// </summary>
        public string AcademicDegree { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// Стаж
        /// </summary>
        public int Experience { get; set; }

        public bool IsValid
        {
            get
            {
                if (Surname == string.Empty) { return false; }
                if (Name == string.Empty) { return false; }
                if (Patronymic == string.Empty) { return false; }
                if (AcademicDegree == string.Empty) { return false; }
                if (JobTitle == string.Empty) { return false; }
                if (Experience <= 0) { return false; }
                return true;
            }
        }

        public Teacher()
        {
            Surname = string.Empty;
            Name = string.Empty;
            Patronymic = string.Empty;
            AcademicDegree = string.Empty;
            JobTitle = string.Empty;
            Experience = 0;
        }

        public Teacher(string surname, string name, string patronymic,
            string academicDegree, string jobTitle, int experience)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            AcademicDegree = academicDegree;
            JobTitle = jobTitle;
            Experience = experience;
        }

        public override string ToString()
        {
            return $"Фамилия: {Surname}\r\n Имя: {Name}\r\n Отчество: {Patronymic}\r\n " +
                $"Ученая степень: {AcademicDegree}\r\n Должность: {JobTitle}\r\n Стаж: {Experience}\r\n";
        }
    }
}
