namespace Services.Interfaces;

public interface ICryptoService
{
    string GenerateSalt();
    string HashPassword(string password, string salt);
    bool VerifyPassword(string password, string hash, string salt);
}
