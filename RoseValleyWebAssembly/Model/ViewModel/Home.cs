namespace RoseValleyWebAssembly.Model.ViewModel
{
    public class Home
    {
        public DateTime StartDt { get; set; } = DateTime.Now;
        public DateTime EndDt { get; set; }

        // по default ще оставим за 1 вечер
        public int NumberOfNights { get; set; } = 1;
    }
}
