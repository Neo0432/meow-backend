using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PawsBackendDotnet.Models.Options;
using PawsBackendDotnet.Models.Entities;
using PawsBackendDotnet.Services.Interfaces;
using System.Text;

namespace PawsBackendDotnet.Services
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly JwtOptions _jwtOptions;
        public JwtAuthService(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public string GenerateToken(User user)
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
