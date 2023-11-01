namespace ClassLibraryDistributionOfStudyLoad
{
    /// <summary>
    /// Предмет
    /// </summary>
    public class Subject : IValidatable
    {
        /// <summary>
        /// Название предмета
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Количество часов
        /// </summary>
        public int NumberOfHours { get; set; }
        public bool IsValid
        {
            get
            {
                if (Name == string.Empty) { return false; }
                if (NumberOfHours <= 0) { return false; }
                return true;
            }
        }

        public Subject()
        {
            Name = string.Empty;
            NumberOfHours = 0;
        }

        public Subject(string name, int numberOfHours)
        {
            Name = name;
            NumberOfHours = numberOfHours;
        }

        public override string ToString()
        {
            return $"Название предмета: {Name}\r\n Количество часов: {NumberOfHours}\r\n";
        }
    }
}
