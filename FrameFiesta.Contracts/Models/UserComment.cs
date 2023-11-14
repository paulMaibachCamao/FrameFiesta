using MongoDB.Bson.Serialization.Attributes;

namespace FrameFiesta.Contracts.Models
{
    public class UserComment
    {
        [BsonId]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}