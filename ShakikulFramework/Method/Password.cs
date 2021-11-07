using System;
using System.Security.Cryptography;
using System.Text;

namespace ShakikulFramework.Method
{
    public class Password
    {
        private string hashes = "$@A%l$o*@";
        public string Encrypt(string password)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);
            using (MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashes));
                using (TripleDESCryptoServiceProvider tripleDes=new TripleDESCryptoServiceProvider(){Key = keys,Mode = CipherMode.ECB,Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform cryptoTransform = tripleDes.CreateEncryptor();
                    byte[] result = cryptoTransform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(result, 0, result.Length);
                }
            }

            return "";
        }
        
        public string Decrypt(string encryptPassword)
        {
            byte[] data = Convert.FromBase64String(encryptPassword);
            using (MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashes));
                using (TripleDESCryptoServiceProvider tripleDes=new TripleDESCryptoServiceProvider(){Key = keys,Mode = CipherMode.ECB,Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform cryptoTransform = tripleDes.CreateDecryptor();
                   byte[] result = cryptoTransform.TransformFinalBlock(data, 0, data.Length);
                   return UTF8Encoding.UTF8.GetString(result);
                }
            }

            return "";
        }
        
        public string Encrypt(string password, string hash)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);
            using (MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes=new TripleDESCryptoServiceProvider(){Key = keys,Mode = CipherMode.ECB,Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform cryptoTransform = tripleDes.CreateEncryptor();
                    byte[] result = cryptoTransform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(result, 0, result.Length);
                }
            }

            return "";
        }
        
        public string Decrypt(string encryptPassword, string hash)
        {
            byte[] data = Convert.FromBase64String(encryptPassword);
            using (MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes=new TripleDESCryptoServiceProvider(){Key = keys,Mode = CipherMode.ECB,Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform cryptoTransform = tripleDes.CreateDecryptor();
                    byte[] result = cryptoTransform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(result);
                }
            }

            return "";
        }
    }
}
