namespace Project.Models
{
    public class User
    {
        public int id { get; set; }
        public string? username { get; set; }
        public byte[]? passwordHash { get; set; }
        public byte[]? passwordSalt { get; set; }
        public string? email { get; set; }
        public string? role { get; set; }
        public string? refreshToken { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime tokenExpires { get; set; }
    }
}