namespace FrameFiesta.Contracts.Models
{
    public class FrameFiestaDocument
    {
        public string Id { get; set; } = "Entities";
        public List<BlogPost> BlogPosts { get; set; }
        public List<UserDB> Users { get; set; }
    }
}