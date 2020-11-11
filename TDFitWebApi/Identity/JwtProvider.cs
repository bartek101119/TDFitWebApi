using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TDFitWebApi.Entities;

namespace TDFitWebApi.Identity
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions jwtOptions;

        public JwtProvider(JwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }
        public string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.RoleName),
                new Claim(ClaimTypes.Name, user.Email),
                /*new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("dd-MM-yyyy")),
                new Claim("Nationality", user.Nationality)*/
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(jwtOptions.JwtExpireDays);

            var token = new JwtSecurityToken(
                jwtOptions.JwtIssuer, // issuer
                jwtOptions.JwtIssuer, // audience
                claims, // lista claimsow dla uzytkownika
                expires: expires, // date do ktorej token bedzie wazny
                signingCredentials: creds // kredencjały do podpisu tokenu
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

    }
}
