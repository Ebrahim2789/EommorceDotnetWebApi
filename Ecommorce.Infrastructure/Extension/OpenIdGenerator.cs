using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Infrastructure.Extension
{
    public class OpenIdGenerator
    {

        private const string Characters = "ABCDEFGHIGKLMNOPQRSTVUWXYZabcdefghijklmnopqrstvuwxyz0123456789";
        public string GenerateOpenId()
        {
            return Guid.NewGuid().ToString("N");
        }
        public string GenerateOpenId(int length)
        {
            var result = new StringBuilder(length);
            using (var mrng = RandomNumberGenerator.Create())
            {
                var data = new byte[length];
                mrng.GetBytes(data);
                foreach (var item in data)
                {
                    result.Append(Characters[item % Characters.Length]);
                }
            }
            return result.ToString();

        }


    }
}
