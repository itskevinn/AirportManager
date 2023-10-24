using System.Security.Cryptography;
using System.Text;

namespace Security.Infrastructure.Security.Encrypt;

public static class Hash
{
    public static string GetSha256(string value)
    {
        var sha256 = SHA256.Create();
        var encoding = new ASCIIEncoding();
        var sb = new StringBuilder();
        var stream = sha256.ComputeHash(encoding.GetBytes(value));
        foreach (var t in stream)
            sb.Append($"{t:x2}");
        return sb.ToString();
    }
}