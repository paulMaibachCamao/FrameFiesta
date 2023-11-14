namespace FrameFiesta.Contracts.Models
{
    public class FrameFiestaDocument
    {
        public string Id { get; set; } = "Entities";
        public List<BlogPostDb> BlogPosts { get; set; } = new List<BlogPostDb>();
        public List<UserDB> Users { get; set; } = new List<UserDB>();
    }
}