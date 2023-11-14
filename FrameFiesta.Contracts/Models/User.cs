using MongoDB.Bson.Serialization.Attributes;

namespace FrameFiesta.Contracts.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public List<UserComment> Comments { get; set; } = new List<UserComment>();
    }
}