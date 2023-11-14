using MongoDB.Bson.Serialization.Attributes;

namespace FrameFiesta.Contracts.Models
{
    public class BlogPostFe
    {
        [BsonId]
        public string Id { get; set; }

        public DateTime Date { get; set; } = new DateTime();
        public string Description { get; set; }
        public string Review { get; set; }
        public List<CommentFe> Comments { get; set; } = new List<CommentFe>();
        public MotionPicture RelatedMotionPicture { get; set; }
    }
}