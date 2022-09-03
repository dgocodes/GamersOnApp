using GamersOn.Domain.Services;
using System.Text;

namespace GamersOn.Infrastructure.Common;

public class PasswordHashService : IPasswordHashService
{
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        var hmac = new System.Security.Cryptography.HMACSHA256();

        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        var hmac = new System.Security.Cryptography.HMACSHA256(passwordSalt);

        var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return computeHash.SequenceEqual(passwordHash);
    }
}
