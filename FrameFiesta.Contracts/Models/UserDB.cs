namespace FrameFiesta.Contracts.Models
{
    public class UserDB
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public List<Comment> Comments { get; set; }
    }
}