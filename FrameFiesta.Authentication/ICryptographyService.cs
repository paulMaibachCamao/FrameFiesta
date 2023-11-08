namespace FrameFiesta.Authentication
{
    public interface ICryptographyService
    {
        string Hash(string password, string salt);
        string GenerateSalt();
    }
}