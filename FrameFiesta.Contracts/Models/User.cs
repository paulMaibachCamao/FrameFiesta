namespace FrameFiesta.Contracts.Models
{
    public class User
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Comment> Comments { get; set; }
    }
}