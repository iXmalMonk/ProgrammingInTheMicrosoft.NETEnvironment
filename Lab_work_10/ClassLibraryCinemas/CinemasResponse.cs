namespace ClassLibraryCinemas
{
    public class CinemasResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage {  get; set; }
        public string Key { get; set; }
        public Cinemas Cinemas { get; set; }
    }
}
