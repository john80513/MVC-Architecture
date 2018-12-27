using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AP.Service.Helper
{
    public class AesHelper
    {
       
        public string NEC_AES_KEY = "MBEN8KNKPRRMAKZHPK92PWH75F4BWRXH";
        public string NEC_AES_IV = "WBGAFD456GCFYW7N";

        public byte[] AesCryptoByNEC(byte[] data)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = Encoding.UTF8.GetBytes(NEC_AES_KEY);
                byte[] iv = Encoding.UTF8.GetBytes(NEC_AES_IV);
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
            catch
            {
                byte[] empty = { };
                return empty;
            }
        }

        public byte[] AesDecryptoByNEC(byte[] crypto)
        {
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = Encoding.UTF8.GetBytes(NEC_AES_KEY);
                byte[] iv = Encoding.UTF8.GetBytes(NEC_AES_IV);
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(crypto, 0, crypto.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
            catch
            {
                byte[] empty = { };
                return empty;
            }
        }
    }
}
