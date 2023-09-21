namespace ClassLibraryDistributionOfStudyLoad
{
    /// <summary>
    /// Нагрузочные данные
    /// </summary>
    public class LoadData
    {
        /// <summary>
        /// Словарь преподавателей
        /// </summary>
        public static Dictionary<string, Teacher> Teachers { get; set; } = new Dictionary<string, Teacher>();
        /// <summary>
        /// Словарь предметов
        /// </summary>
        public static Dictionary<string, Subject> Subjects { get; set; } = new Dictionary<string, Subject>();
        /// <summary>
        /// Список нагрузок
        /// </summary>
        public static List<Load> Loads { get; set; } = new List<Load>();
    }
}
