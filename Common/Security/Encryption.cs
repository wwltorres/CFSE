using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CFSE.Common.Security
{
    public static class Encryption
    {
        private const string key = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCovhr3g92GUzt1OdNvDIm73ZvO";


        public static string Encrypt(string text)
        {
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            string result = string.Empty;

            byte[] keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            byte[] textByte = UTF8Encoding.UTF8.GetBytes(text);

            hashmd5.Clear();
            
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();

            byte[] byteResult = cTransform.TransformFinalBlock(textByte, 0, textByte.Length);

            tdes.Clear();

            result = Convert.ToBase64String(byteResult, 0, byteResult.Length);

            return result;
        }

        public static string Decrypt(string text)
        {
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            string result = string.Empty;
            byte[] keyArray;
            byte[] textByte = Convert.FromBase64String(text);

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();
            
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] byteResult = cTransform.TransformFinalBlock(textByte, 0, textByte.Length);

            tdes.Clear();

            result = UTF8Encoding.UTF8.GetString(byteResult);

            return result;
        }
    }
}
