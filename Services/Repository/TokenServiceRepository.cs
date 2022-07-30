using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Project.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace Project.Services
{
    public class TokenServices : IGenerateToken
    {
        private readonly IConfiguration _configure;

        public TokenServices(IConfiguration configure)
        {
            _configure = configure;
        }

        //Service to generate Access Token
        public string GenerateAccessToken(User user)
        {
            
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.username),
            new Claim("role", user.role)
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configure.GetSection("JwtConfig:Key").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        //Service to generate refresh Token
        public RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
            return refreshToken;
        }

        //Service to set refresh token in response headers
        public async Task SetRefreshToken(RefreshToken newRefreshToken, HttpResponse Response)
        {

            var cookie = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookie);
        }
    }
}