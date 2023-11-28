using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserProjectToSend.Apliaction.Asbtractions;

namespace UserProjectToSend.Apliaction.Services;

public class SecurityService:ISecurityService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public SecurityService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }
    #region PasswordHash
    public byte[] GetPasswordHash(string password, byte[] passwordSalt)
    {
        string PasswordSaltPlusString = _configuration.GetSection("AppSettings:PasswordKey").Value + Convert.ToBase64String(passwordSalt);

        byte[] passwordHash = KeyDerivation.Pbkdf2(
            password: password,
            salt: Encoding.ASCII.GetBytes(PasswordSaltPlusString),
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 100000,
            numBytesRequested: 256 / 8
        );
        return passwordHash;
    }
    #endregion

    public dynamic CreateToken(int userId, string role)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim("userId", userId.ToString())
        };
        try
        {
            SymmetricSecurityKey tokenKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("Token").Value));

            SigningCredentials credentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha512);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(1)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(descriptor);
            string tokenString = tokenHandler.WriteToken(token);
            /*_httpContextAccessor.HttpContext?.Response.Cookies.Append("token", tokenString, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            });*/

            return (tokenString, descriptor.Expires.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
