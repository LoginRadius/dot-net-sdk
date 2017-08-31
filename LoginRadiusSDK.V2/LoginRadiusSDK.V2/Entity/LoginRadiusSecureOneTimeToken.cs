using LoginRadiusSDK.V2.Models;
using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using LoginRadiusSDK.V2.Api;

namespace LoginRadiusSDK.V2.Entity
{
    public static class LoginRadiusSecureOneTimeToken
    {
        public static string GetSott(SottDetails sottDetails)
        {
            string secret = LoginRadiusResource.ConfigDictionary[BaseConstants.LoginRadiusApiKey];
            string key = LoginRadiusResource.ConfigDictionary[BaseConstants.LoginRadiusApiSecret];

            if (!string.IsNullOrWhiteSpace(secret) && !string.IsNullOrWhiteSpace(key))
            {
                string tempToken;

                if (sottDetails.Sott.StartTime != null && sottDetails.Sott.EndTime != null)
                {
                    tempToken = Convert.ToDateTime(sottDetails.Sott.StartTime)
                                    .ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture) + "#" + key + "#" +
                                Convert.ToDateTime(sottDetails.Sott.EndTime)
                                    .ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture);
                }
                else
                {
                    tempToken = DateTime.UtcNow.ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture) + "#" + key +
                                "#" +
                                DateTime.UtcNow.AddMinutes(10).ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture);
                }

                var token = Encrypt(tempToken, secret);
                var hash = CreateMd5(token);
                //return token.Replace("+", "%2B") + "*" + hash;
                return token + "*" + hash;
            }
            return string.Empty;
        }

        private const string InitVector = "tu89geji340t89u2";

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int Keysize = 256;

        private static string Encrypt(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var password = new Rfc2898DeriveBytes(passPhrase, new byte[8], 10000);
            byte[] keyBytes = password.GetBytes(Keysize / 8);
            var symmetricKey = new RijndaelManaged {Mode = CipherMode.CBC};
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
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