namespace FrameFiesta.Contracts.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Review { get; set; }
        public List<Comment> Comments { get; set; }
        public MotionPicture RelatedMotionPicture { get; set; }
    }
}