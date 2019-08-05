using System;

using System.Text;


using System.Globalization;
using System.IO;
using System.Security.Cryptography;


namespace LoginRadiusSDK.V2.Common
{
    public  class LoginRadiusSecureOneTimeToken
    {
        public  string GetSott(Sott sottAuth)
        {
            string secret = LoginRadiusResource.ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret];
            string key = LoginRadiusResource.ConfigDictionary[LRConfigConstants.LoginRadiusApiKey];

            if (!string.IsNullOrWhiteSpace(secret) && !string.IsNullOrWhiteSpace(key))
            {
                string tempToken;

                if (sottAuth.StartTime != null && sottAuth.EndTime != null)
                {
                    tempToken =
                        $"{Convert.ToDateTime(sottAuth.StartTime).ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture)}#{key}#{Convert.ToDateTime(sottAuth.EndTime).ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture)}";
                }
                else
                {
                    tempToken = DateTime.UtcNow.ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture) + "#" + key +
                                "#" +
                                DateTime.UtcNow.AddMinutes(10).ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture);
                }

                var token = Encrypt(tempToken, secret);
                var hash = CreateMd5(token);
                return token + "*" + hash;
            }
            return string.Empty;
        }

        private const string InitVector = "tu89geji340t89u2";

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int Keysize = 256;

        private static string Encrypt(string plainText, string passPhrase)
        {
            Aes aesAlg = Aes.Create();
            byte[] toBytes = Encoding.ASCII.GetBytes(InitVector);
            aesAlg.IV = toBytes;
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var password = new Rfc2898DeriveBytes(passPhrase, new byte[8], 10000);
            byte[] keyBytes = password.GetBytes(Keysize / 8);
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(keyBytes, aesAlg.IV);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Flush();
            cryptoStream.Flush();
            return Convert.ToBase64String(cipherTextBytes);
        }

        private static string CreateMd5(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            return CreateMd5(inputBytes);
        }

        private static string CreateMd5(byte[] inputBytes)
        {
            // Use input string to calculate MD5 hash
            var md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (byte t in hashBytes)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
