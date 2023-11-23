using MongoDB.Bson.Serialization.Attributes;

namespace FrameFiesta.Contracts.Models
{
    public class UserDb
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public List<UserComment> Comments { get; set; } = new List<UserComment>();
    }
}