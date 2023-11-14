using MongoDB.Bson.Serialization.Attributes;

namespace FrameFiesta.Contracts.Models
{
    public class BlogPostDb
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime Date { get; set; } = new DateTime();
        public string Description { get; set; }
        public string Review { get; set; }
        public List<BlogComment> Comments { get; set; } = new List<BlogComment>();
        public MotionPicture RelatedMotionPicture { get; set; }
    }
}