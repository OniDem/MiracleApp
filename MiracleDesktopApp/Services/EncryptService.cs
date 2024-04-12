using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MiracleApp.Services
{
    public static class EncryptService
    {
        private static readonly string _key = "5Yd579q9MCGh7kScFYbaRuDpFa0ec1NEJ2LgtDtV7n4z7X5BuBhKupcGTGmR2cvLSJEUXhWNmP6ARzT1Fb1ZGr7auMUHLAb6vT8Fx8YtWpnmwH6pmxNxVz9Etg8fu8UtSJA4wY2Er2jD2KFKzxFu1JmJzNQ7jFdnc71xEkkKepmX44Me4xmvgJrKAXfVVxdz8Q8nk88amxjWEC41vxNHRBVVbdQjP2gB5mj45SYW3zyrXXZqi4c7SSEznNg8Uwcv69H9fy8wSwYN6aVQf7FNZENgkeHZ9MRYMaqLFJ1vvwJivn4VL3eCLz1mTp59SAiqPTun8jYHpwuXPkV3qE9VMRb9DcNfAM3Y85XiPn77XSFw4MFiDggAew73gt8ky1AJDa58mRxin31EuYJnHj958jy6kChKgg1jLwBjEj6HRMK3SxYbP5d3HUjK0GKbzqZ9DUUhwVVijaV7zRdY05ya5TufnNN8t2t76081xDGSKfE9NpnyumrPivPKBUmHjB7K";
        private static readonly byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        public static async Task<byte[]> EncryptStringToByteArrayAsync(string value)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(_key);
            aes.IV = IV;
            using MemoryStream output = new();
            using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);
            await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(value));
            await cryptoStream.FlushFinalBlockAsync();
            return output.ToArray();
        }

        public static async Task<string> DecryptByteArrayToStringAsync(byte[] value)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(_key);
            aes.IV = IV;
            using MemoryStream input = new(value);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);
            return Encoding.Unicode.GetString(output.ToArray());
        }

        private static byte[] DeriveKeyFromPassword(string password)
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes equal 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password), emptySalt, iterations, hashMethod, desiredKeyLength);
        }
    }
}
