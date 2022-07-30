namespace Project.Services
{
    public interface IPasswordHash
    {
        public void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasssword(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}