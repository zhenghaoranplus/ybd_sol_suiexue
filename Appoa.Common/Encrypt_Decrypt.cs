using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Appoa.Common
{
    public class Encrypt_Decrypt
    {
        #region SHA1加密字符串
        public string EncryptSHA1(string str)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] str1 = Encoding.UTF8.GetBytes(str);
            byte[] str2 = sha1.ComputeHash(str1);
            sha1.Clear();
            (sha1 as IDisposable).Dispose();
            return Convert.ToBase64String(str2);
        }
        #endregion


    }
}
