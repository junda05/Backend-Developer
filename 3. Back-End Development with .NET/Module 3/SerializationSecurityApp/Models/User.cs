using System.Security.Cryptography;
using System.Text;

public class User
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }

    // Encrypt Sensitive Data Before Serialization
    public void EncryptData()
    {
        Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
    }

    // Implement Data Integrity Checks - Generate and verify the hash to maintain data integrity.
    public string GenerateHash()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(ToString()));
            return Convert.ToBase64String(hashBytes);
        }
    }

    public override string ToString()
    {
        return $"{Name}|{Email}|{Password}";
    }
}