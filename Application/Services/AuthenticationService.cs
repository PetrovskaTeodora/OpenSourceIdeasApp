using Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public string GenerateToken(Guid userId)
        {
            string encoded = Convert.ToBase64String(userId.ToByteArray());
            encoded = encoded.Replace("/", "_").Replace("+", "-");
            return encoded.Substring(0, 22);
        }

        public Guid GetUserIdFromToken(string token)
        {
            if (token == "" || token == null) return Guid.Empty;

            token = token.Replace("_", "/").Replace("-", "+");
            byte[] buffer = Convert.FromBase64String(token + "==");
            return new Guid(buffer);
        }
    }
}
