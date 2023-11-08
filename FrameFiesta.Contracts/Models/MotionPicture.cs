namespace FrameFiesta.Contracts.Models
{
    public class MotionPicture
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public List<string> Actors { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public List<string> Genres { get; set; }
        public int InitialRelease { get; set; }
    }
}