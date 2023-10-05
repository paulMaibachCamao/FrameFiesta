namespace FrameFiesta.Contracts.Models
{
    public class MotionPicture
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public List<string> Actors { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public List<string> Genre { get; set; }
        public DateTime InitialRelease { get; set; }
        public List<string> Comments { get; set; }
    }
}