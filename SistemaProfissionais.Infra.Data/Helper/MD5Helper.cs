using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SistemaProfissionais.Infra.Data.Helper
{
    public class MD5Helper
    {
        public static string Encrypt(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            var saida = string.Empty;
            foreach (var item in hash)
            {
                saida += item.ToString("X2");
            }
            return saida;
        }
    }
}
