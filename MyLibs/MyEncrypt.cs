using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;

namespace MyVideoExplorer
{
    class MyEncrypt
    {
        // aes is 128 Rijndael  .. so aes256
        // http://stackoverflow.com/questions/13486109/rijndaelmanaged-vs-aescryptoserviceprovider-aes-encryption

        //Shared 256 bit Key and IV here
        public static string[] sharedKeys = {
            "S3TpGfvZx2yeo5mXKCi9DH8QsthEJ7VF",
            "eMEbAqj8yYGdBnVWNFfXsChKuQZcJLwx",
            "MPZp9UGkgutivozNhx7a4KEydVJ6XwFB",
            "8DeNAyKXvTEiLHmkUQsf9GqghZoCPnWY",
            "cPCS9dHMbnUguhE6aB5xKQm2AJFo78eL",
            "qNMbWV6YvtRPeiFndxLfjwKEQU7zZpAa",
            "m3zMTE5YGq6KospWcPFt7CgDLbdxBjRH",
            "qtb9eNLKZaXPRGgk6p8f3TsjWYwnBiC4",
            "58NoFhrDnH9PidyKCBxQaWmwf6vjtEAL"
                                            }; //32 chr shared ascii string (32 * 8 = 256 bit)

        public static string DecryptRJ256(string prm_key, string prm_iv, string prm_text_to_decrypt)
        {

            var sEncryptedString = prm_text_to_decrypt;

            var myRijndael = new RijndaelManaged()
            {
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC,
                KeySize = 256,
                BlockSize = 256
            };

            var key = Encoding.ASCII.GetBytes(prm_key);
            // var IV = Encoding.ASCII.GetBytes(prm_iv);
            byte[] IV = Convert.FromBase64String(prm_iv);

            var decryptor = myRijndael.CreateDecryptor(key, IV);

            var sEncrypted = Convert.FromBase64String(sEncryptedString);

            var fromEncrypt = new byte[sEncrypted.Length];

            var msDecrypt = new MemoryStream(sEncrypted);
            var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            // string decrypt = Encoding.UTF8.GetString(fromEncrypt);
            string decrypt = Convert.ToBase64String(fromEncrypt);
            return decrypt;
        }

        public static string EncryptRJ256(string prm_key, string prm_iv, string prm_text_to_encrypt)
        {

            var sToEncrypt = prm_text_to_encrypt;

            var myRijndael = new RijndaelManaged()
            {
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC,
                KeySize = 256,
                BlockSize = 256
            };

            var key = Encoding.ASCII.GetBytes(prm_key);
            // var IV = Encoding.ASCII.GetBytes(prm_iv);
            byte[] IV = Convert.FromBase64String(prm_iv);

            var encryptor = myRijndael.CreateEncryptor(key, IV);

            var msEncrypt = new MemoryStream();
            var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            var toEncrypt = Convert.FromBase64String(sToEncrypt);

            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            var encrypted = msEncrypt.ToArray();

            string encrypt = Convert.ToBase64String(encrypted);
            return encrypt;
        }

        public static string GenerateIV()
        {
            var myRijndael = new RijndaelManaged()
            {
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC,
                KeySize = 256,
                BlockSize = 256
            };
            myRijndael.GenerateIV();

            string iv = Convert.ToBase64String(myRijndael.IV);
            // iv = iv.Substring(0, 32);
            return iv;
        }
 

    }
}
