using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace FrameFiesta.Contracts.Models
{
    [SwaggerDiscriminator("type")]
    [BsonKnownTypes(typeof(Series), typeof(Film))]
    public class MotionPicture
    {
        public string Title { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public List<string> Actors { get; set; } = new List<string>();
        public double Rating { get; set; }
        public string Image { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        public int InitialRelease { get; set; }
    }
}