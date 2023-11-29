using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserProjectToSend.Apliaction.Services;

using System.Security.Cryptography;
using UserProjectToSend.Apliaction.AbstractionServices;

public class SecurityService:ISecurityService
{
    private readonly IConfiguration _configuration;
    public SecurityService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    #region PasswordHash
    /*public byte[] GetPasswordHash(string password, byte[] passwordSalt)
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
    }*/
    public string GetPasswordHash(string password)
    {
        var sha1 = new SHA1CryptoServiceProvider();

        byte[] password_bytes = Encoding.ASCII.GetBytes(password);
        byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);
        return Convert.ToBase64String(encrypted_bytes);
    }
    #endregion

    public dynamic CreateToken(int userId)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim("userId", userId.ToString())
        };
        try
        {
            SymmetricSecurityKey tokenKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("Token").Value));

            SigningCredentials credentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(1)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(descriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
