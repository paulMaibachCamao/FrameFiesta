namespace FrameFiesta.Authentication
{
    public class CryptographyService : ICryptographyService
    {
        public string GenerateSalt()
        {
            Random res = new Random();
            var str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 5;

            var salt = "";

            for (int i = 0; i < size; i++)
            {
                int x = res.Next(str.Length);
                salt = salt + str[x];
            }

            return salt;
        }

        public string Hash(string password, string salt)
        {
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
    }
}