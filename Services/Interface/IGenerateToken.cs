using Project.Models;

namespace Project.Services
{
    public interface IGenerateToken
    {
        public string GenerateAccessToken(User user);
        public RefreshToken GenerateRefreshToken();
        public Task SetRefreshToken(RefreshToken newRefreshToken, HttpResponse Response);
    }
}