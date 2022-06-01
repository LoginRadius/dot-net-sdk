using System;

using System.Text;


using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using LoginRadiusSDK.V2.Api.Advanced;

namespace LoginRadiusSDK.V2.Common
{
    public class LoginRadiusSecureOneTimeToken
    {

        /// <summary>
        /// Generate SOTT Manually.
        /// </summary>
        /// <param name="sottAuth">Model Class containing Definition of payload for SOTT</param>
        /// <param name="apiKey">LoginRadius Api Key.</param>
        /// <param name="apiSecret">LoginRadius Api Secret.</param>
        /// <returns>Response containing SOTT</returns>
        /// 

        public string GetSott(Sott sottAuth, string apiKey = "", string apiSecret = "", bool getLrServerTime=false)
        {

            string secret = !string.IsNullOrWhiteSpace(apiSecret) ? apiSecret : LoginRadiusResource.ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret];

            string key = !string.IsNullOrWhiteSpace(apiKey) ? apiKey : LoginRadiusResource.ConfigDictionary[LRConfigConstants.LoginRadiusApiKey];

            string timeDifference = !string.IsNullOrWhiteSpace(sottAuth.TimeDifference) ? sottAuth.TimeDifference : "10";
            int time;
            bool isParsable=Int32.TryParse(timeDifference, out time);

            string tempToken;
           

            if (!string.IsNullOrWhiteSpace(secret) && !string.IsNullOrWhiteSpace(key))
            {
                tempToken = DateTime.UtcNow.ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture) + "#" + key +
                                "#" +
                                DateTime.UtcNow.AddMinutes(isParsable ? time : 10).ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture);

               
                if (!string.IsNullOrWhiteSpace(sottAuth.StartTime) && !string.IsNullOrWhiteSpace(sottAuth.EndTime))
                {
                    tempToken =
                        $"{Convert.ToDateTime(sottAuth.StartTime).ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture)}#{key}#{Convert.ToDateTime(sottAuth.EndTime).ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture)}";
                }
                else if(getLrServerTime)
                {
                    
                    var apiResponse = new ConfigurationApi().GetServerInfo(isParsable ? time : 10).Result;
                    if (apiResponse.RestException == null)
                    {
                        if(!string.IsNullOrWhiteSpace(apiResponse.Response.Sott.StartTime) && !string.IsNullOrWhiteSpace(apiResponse.Response.Sott.EndTime)){
                            tempToken =
                       $"{Convert.ToDateTime(apiResponse.Response.Sott.StartTime).ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture)}#{key}#{Convert.ToDateTime(apiResponse.Response.Sott.EndTime).ToString("yyyy/M/d H:m:s", CultureInfo.InvariantCulture)}";
                        }
                    }
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
