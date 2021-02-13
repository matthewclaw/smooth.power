using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Smooth.Power.Data.Entities;
using Smooth.Power.Logic;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Logic
{
    public static class InternalTools
    {
        public static string Hash(this string s)
        {
            string strSalt = "s4IHb85VbnO9UzeJuS8D0g==";
            byte[] salt = Convert.FromBase64String(strSalt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: s,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
        public static string GenerateJwtToken(this UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = GetJwtLifeTime(),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static DateTime GetJwtLifeTime()
        {
            int units = 0;
            if (Regex.IsMatch(Settings.JwtLifetime, @"[0-9]+"))
            {
                units = Convert.ToInt32(Regex.Match(Settings.JwtLifetime, @"[0-9]+").Value);
            }
            else
            {
                return DateTime.UtcNow.AddDays(5);
            }
            string lower = Settings.JwtLifetime.ToLower();

            if (Regex.IsMatch(lower, @"m(in)?"))
            {
                return DateTime.UtcNow.AddMinutes(units);
            }
            else if (Regex.IsMatch(lower, @"h(ou)?r?"))
            {
                return DateTime.UtcNow.AddHours(units);
            }
            else if (Regex.IsMatch(lower, @"d(ay)?"))
            {
                return DateTime.UtcNow.AddDays(units);
            }
            else if (Regex.IsMatch(lower, @"s(ec)?"))
            {
                return DateTime.UtcNow.AddSeconds(units);
            }
            else
            {
                return DateTime.UtcNow.AddDays(units);
            }
        }
        public static UserEntity GetUser(this ControllerBase controller)
        {
            return (UserEntity)controller.HttpContext.Items["User"];

        }
    }
}
